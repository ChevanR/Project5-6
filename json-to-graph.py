import json
from bokeh.plotting import figure, show
from bokeh.layouts import row
from bokeh.models import HoverTool, ColumnDataSource


# Function to load data from JSON file
def load_data_from_json(filepath):
    with open(filepath, 'r') as file:
        return json.load(file)


# Ask the user for the JSON file path and remove any quotes
while True:
    filename = input("Enter the path to the JSON data file: ").replace('"', '').replace("'", "")

    try:
        # Try loading the data from the given file path
        data = load_data_from_json(filename)
        break  # If successful, break out of the loop
    except FileNotFoundError:
        print(f"Error: The file '{filename}' was not found. Please try again.")
    except json.JSONDecodeError:
        print(f"Error: The file '{filename}' is not a valid JSON file. Please try again.")

# Prepare data lists
total_latency_ms = []
network_latency_ms = []
client_frame_rate = []
server_frame_rate = []
bitrate_MBps = []

# Populate lists with data from JSON entries
for index, entry in enumerate(data):
    # Ensure that we access the correct structure
    event_data = entry['event_type']['data']

    if entry['event_type']['id'] == "StatisticsSummary":
        continue
    elif entry['event_type']['id'] == "GraphStatistics":
        # Extract the required values from the nested data
        total_latency_ms.append(event_data['total_pipeline_latency_s'] * 1000)  # Latency in ms
        network_latency_ms.append(event_data['network_s'] * 1000)  # Network latency in ms
        client_frame_rate.append(event_data['client_fps'])  # Client FPS
        server_frame_rate.append(event_data['server_fps'])  # Server FPS
        bitrate_MBps.append(event_data['actual_bitrate_bps'] / (8 * 1024))  # Bitrate in Mbps

# Create time_index as a range based on the length of the data
time_index = list(range(len(total_latency_ms)))

# Data sources for each figure
latency_source = ColumnDataSource(data=dict(
    x=time_index,
    total_latency=total_latency_ms,
    network_latency=network_latency_ms
))

fps_source = ColumnDataSource(data=dict(
    x=time_index,
    client_fps=client_frame_rate,
    server_fps=server_frame_rate
))

bitrate_source = ColumnDataSource(data=dict(
    x=time_index,
    bitrate=bitrate_MBps
))

# Create and configure the Latency Graph
latency_figure = figure(title="Total and Network Latency Over Time",
                        x_axis_label="Time Index", y_axis_label="Latency (milliseconds)",
                        width=600, height=800)
latency_figure.line('x', 'total_latency', source=latency_source, legend_label="Total Latency (ms)",
                    line_width=2)
latency_figure.line('x', 'network_latency', source=latency_source, legend_label="Network Latency (ms)",
                    line_color="green", line_width=2)
latency_figure.legend.label_text_font_size = "10pt"

# Add HoverTool to Latency Figure with total and network latency
latency_hover = HoverTool(tooltips=[
    ("Total Latency (ms)", "@total_latency"),
    ("Network Latency (ms)", "@network_latency"),
], mode="vline", renderers=[latency_figure.renderers[0]])
latency_figure.add_tools(latency_hover)

# Create and configure the FPS Graph
fps_figure = figure(title="Client and Server Frame Rate Over Time",
                    x_axis_label="Time Index", y_axis_label="Frames Per Second (FPS)",
                    width=600, height=800)
fps_figure.line('x', 'client_fps', source=fps_source, legend_label="Client FPS", line_width=2)
fps_figure.line('x', 'server_fps', source=fps_source, legend_label="Server FPS", line_color="green", line_width=2)
fps_figure.legend.label_text_font_size = "10pt"

# Add HoverTool to FPS Figure with both FPS values
fps_hover = HoverTool(tooltips=[
    ("Client FPS", "@client_fps"),
    ("Server FPS", "@server_fps")
], mode="vline", renderers=[fps_figure.renderers[0]])
fps_figure.add_tools(fps_hover)

# Create and configure the Bitrate Graph
bitrate_figure = figure(title="Bitrate Over Time",
                        x_axis_label="Time Index", y_axis_label="Bitrate (MBps)",
                        width=600, height=800)
bitrate_figure.line('x', 'bitrate', source=bitrate_source, legend_label="Bitrate", line_width=2)
bitrate_figure.legend.label_text_font_size = "10pt"

# Add HoverTool to Bitrate Figure showing bitrate
bitrate_hover = HoverTool(tooltips=[
    ("Bitrate (MBps)", "@bitrate")
], mode="vline")
bitrate_figure.add_tools(bitrate_hover)

# Display all three figures in a row layout
show(row(latency_figure, fps_figure, bitrate_figure))

