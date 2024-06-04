#!/bin/bash

# Get the CPU usage
cpu_usage=$(top -bn1 | grep "Cpu(s)" | sed "s/.*, *\([0-9.]*\)%* id.*/\1/" | awk '{print 100 - $1"%"}')

# Get the memory usage
memory_usage=$(free -m | awk 'NR==2{printf "%.2f%%", $3*100/$2 }')

echo "CPU Usage: $cpu_usage"
echo "Memory Usage: $memory_usage"