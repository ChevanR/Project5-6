# How to use
- Start the ALVR streamer and connect with the VR headset
- Run the "alvr-socket.py" script and let it generate a log file, whilst running the session
- Close the script with using CRTL+C twice, when you are done with the VR session
  
Now there will be a a folder named alvr-logs made with a json file inside with the statistics logs of that previous session.

It contains the following two entries:
### Json data
##### Statistics data
```json
{ 
    "timestamp": "23:38:08.475", 
    "event_type": { 
        "id": "GraphStatistics", 
        "data": { 
            "total_pipeline_latency_s": 0.051938575, 
            "game_time_s": 0.0078286, 
            "server_compositor_s": 0.0001978, 
            "encoder_s": 0.0068522, 
            "network_s": 0.002433477, 
            "decoder_s": 0.010199115, 
            "decoder_queue_s": 0.022944732, 
            "client_compositor_s": 0.001482654, 
            "vsync_queue_s": 0.0, 
            "client_fps": 67.1885, 
            "server_fps": 60.442684, 
            "nominal_bitrate": { 
                "scaled_calculated_bps": null, 
                "decoder_latency_limiter_bps": null, 
                "network_latency_limiter_bps": null, 
                "encoder_latency_limiter_bps": null, 
                "manual_max_bps": null, 
                "manual_min_bps": null, 
                "requested_bps": 30000000.0 
            }, 
            "actual_bitrate_bps": 39449.727 
        } 
    } 
} 
```
Value explanation <\placeholder>
##### Statistics Summary
```json
{ 
    "timestamp": "23:38:08.959", 
    "event_type": { 
        "id": "StatisticsSummary", 
        "data": { 
            "video_packets_total": 84666, 
            "video_packets_per_sec": 60, 
            "video_mbytes_total": 23, 
            "video_mbits_per_sec": 0.00576, 
            "total_latency_ms": 52.106342, 
            "network_latency_ms": 2.3668852, 
            "encode_latency_ms": 7.4662, 
            "decode_latency_ms": 8.548883, 
            "packets_lost_total": 0, 
            "packets_lost_per_sec": 0, 
            "client_fps": 64, 
            "server_fps": 58, 
            "battery_hmd": 100, 
            "hmd_plugged": true 
        } 
    } 
} 
```
Value explanation <\placeholder>

To graph this data, run the "json-to-graph.py" script fill in the file location and see the newly created .html file which contains the graphs, <b>be sure to give it another name before graphing a new json logging file, as it will overwrite it.</b>