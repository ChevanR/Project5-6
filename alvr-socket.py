#!/usr/bin/env python

"""Client using the asyncio API."""

import asyncio
import os
import json
from datetime import datetime
from websockets.asyncio.client import connect
import atexit
import signal

LOG_DIR = "alvr-logs"

# Ensure the log directory exists
os.makedirs(LOG_DIR, exist_ok=True)
RECEIVE_TIMEOUT = 15  # Time to wait for a message before timing out (in seconds)

# Generate a unique filename based on the current date and time
filename = datetime.now().strftime("%Y%m%d_%H%M%S_%f") + ".json"
LOG_FILE = os.path.join(LOG_DIR, filename)


# Function to close JSON array in log file
def close_json_array():
    # Remove any trailing comma and close the JSON array with a bracket
    with open(LOG_FILE, 'rb+') as f:
        f.seek(-1, os.SEEK_END)  # Go to the last byte in the file
        last_char = f.read(1)

        # If the last character is a comma, remove it
        if last_char == b',':
            f.seek(-1, os.SEEK_END)
            f.truncate()  # Remove the trailing comma

        # Append the closing bracket
        f.write(b']')

# Register the function to run when the program exits
atexit.register(close_json_array)

async def hello():
    async with connect("ws://localhost:8082/api/events",ping_interval=10, ping_timeout=5) as websocket:
        # Write the JSON data to a new file
        with open(LOG_FILE, 'a') as f:
            f.write('[')

            while True:
                # Receive a message from the WebSocket
                message = await asyncio.wait_for(websocket.recv(), timeout=RECEIVE_TIMEOUT)
                # Parse the message as JSON
                try:
                    data = json.loads(message)
                except json.JSONDecodeError:
                    print("Received invalid JSON message")
                    continue

                json.dump(data, f, indent=4)
                f.write(',')


if __name__ == "__main__":
    asyncio.run(hello())
