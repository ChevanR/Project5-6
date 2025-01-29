import json
import matplotlib.pyplot as plt
import seaborn as sns
import pandas as pd

# Initialize an empty list to collect data
data = []

# Define x-axis variables
x_axis_data = ["vr_latency", "haptic_latency"]

z_metrics = ["motionSickness", "taskPerformance", "vr_usability", "haptic_accuracy", "haptic_responsiveness"]

# Prompt user to enter file names (comma-separated) and trim whitespace
file_list = input("Enter the JSON filenames (comma-separated): ").split(',')

# Load each JSON file specified
for filename in file_list:
    filename = filename.strip().strip('"').strip("'")
    try:
        with open(filename, 'r') as file:
            entries = json.load(file)
            if isinstance(entries, list):
                for entry in entries:
                    if entry.get("vr_latency", 0) <= 0 and entry.get("haptic_latency", 0) <= 0:
                        continue  # Skip entries with invalid latency values
                    cleaned_entry = {k: (v.strip() if isinstance(v, str) else v) for k, v in entry.items()}
                    data.append(cleaned_entry)
            else:
                if entries.get("vr_latency", 0) != 0 or entries.get("haptic_latency", 0) != 0:
                    cleaned_entry = {k: (v.strip() if isinstance(v, str) else v) for k, v in entries.items()}
                    data.append(cleaned_entry)
    except Exception as e:
        print(f"Error loading {filename}: {e}")

# Convert the list of dictionaries to a DataFrame
df = pd.DataFrame(data)

# Adjust latency values for testerId 1 & 2 if needed
df.loc[df['testerId'].isin(["1", "2"]), 'vr_latency'] *= 4
df.loc[df['testerId'].isin(["1", "2"]), 'haptic_latency'] *= 4

# Required columns check
required_columns = {"vr_latency", "haptic_latency", "testerId"}
for entry in z_metrics:
    required_columns.add(entry)

if not required_columns.issubset(df.columns):
    print("Data does not contain all required columns:", required_columns)
else:
    # Metrics to compare against the x-axis data
    y_metrics = ["motionSickness", "taskPerformance", "vr_usability", "haptic_accuracy","haptic_responsiveness"]

    # Create subplots based on x-axis variables and y-metrics
    fig, axes = plt.subplots(len(y_metrics), len(x_axis_data), figsize=(15, 10))  

    for i, x_col in enumerate(x_axis_data):
        for j, y_col in enumerate(y_metrics):
            ax = axes[j, i] if len(y_metrics) > 1 else axes[i]
            sns.scatterplot(data=df, x=x_col, y=y_col, hue="testerId", palette="tab10", legend=False, ax=ax)
            for tester_id, group in df.groupby("testerId"):
                ax.plot(group[x_col], group[y_col], marker="o", label=f"User {tester_id}")
            ax.set_title(f"{y_col} vs {x_col}")
            ax.set_xlabel(x_col)
            ax.set_ylabel(y_col)


    plt.tight_layout()
    plt.show()
