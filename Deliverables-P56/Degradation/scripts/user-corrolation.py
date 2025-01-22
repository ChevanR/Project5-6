import json
import matplotlib.pyplot as plt
import seaborn as sns
import pandas as pd

# Initialize an empty list to collect data
data = []

# Prompt user to enter file names (comma-separated) and trim whitespace
file_list = input("Enter the JSON filenames (comma-separated): ").split(',')

# Load each JSON file specified
for filename in file_list:
    # Strip whitespace and any extra surrounding quotes from the filename
    filename = filename.strip().strip('"').strip("'")
    try:
        with open(filename, 'r') as file:
            entries = json.load(file)
            # Check if the JSON data is a list
            if isinstance(entries, list):
                # Add each entry in the list to the data, trimming whitespace if needed
                for entry in entries:
                    # Skip entries where latency is zero
                    if entry.get("latency", 0) <= 0:
                        continue
                    cleaned_entry = {k: (v.strip() if isinstance(v, str) else v) for k, v in entry.items()}
                    data.append(cleaned_entry)
            else:
                # Single JSON object case (for completeness)
                if entries.get("latency", 0) != 0:
                    cleaned_entry = {k: (v.strip() if isinstance(v, str) else v) for k, v in entries.items()}
                    data.append(cleaned_entry)
    except Exception as e:
        print(f"Error loading {filename}: {e}")

# Convert the list of dictionaries to a DataFrame
df = pd.DataFrame(data)

df.loc[df['testerId'].isin(["1", "2"]), 'latency'] *= 4
# Check if data loaded and has the required columns
required_columns = {"latency", "motionSickness", "taskPerformance", "usability", "testerId"}

if not required_columns.issubset(df.columns):
    print("Data does not contain all required columns:", required_columns)
else:
    # Create scatter and line plots to analyze the relationships
    plt.figure(figsize=(15, 15))

    # Scatter plot with lines: Motion Sickness vs. Latency
    plt.subplot(3, 1, 1)
    sns.scatterplot(data=df, x="latency", y="motionSickness", hue="testerId", palette="tab10", legend="full")
    for tester_id, group in df.groupby("testerId"):
        plt.plot(group["latency"], group["motionSickness"], marker="o", label=f"User {tester_id}")
    plt.title("Motion Sickness vs Latency")
    plt.xlabel("Latency (ms)")
    plt.ylabel("Motion Sickness Level")

    # Scatter plot with lines: Task Performance vs. Latency
    plt.subplot(3, 1, 2)
    sns.scatterplot(data=df, x="latency", y="taskPerformance", hue="testerId", palette="tab10", legend=False)
    for tester_id, group in df.groupby("testerId"):
        plt.plot(group["latency"], group["taskPerformance"], marker="o", label=f"User {tester_id}")
    plt.title("Task Performance vs Latency")
    plt.xlabel("Latency (ms)")
    plt.ylabel("Task Performance Score")

    # Scatter plot with lines: Usability vs. Latency
    plt.subplot(3, 1, 3)
    sns.scatterplot(data=df, x="latency", y="usability", hue="testerId", palette="tab10", legend=False)
    for tester_id, group in df.groupby("testerId"):
        plt.plot(group["latency"], group["usability"], marker="o", label=f"User {tester_id}")
    plt.title("Usability vs Latency")
    plt.xlabel("Latency (ms)")
    plt.ylabel("Usability Score")

    # Adjust layout for better spacing
    plt.tight_layout()

    # Show the plot
    plt.show()
