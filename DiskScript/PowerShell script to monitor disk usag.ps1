# PowerShell script to monitor disk usage on a Windows VM

# Define the threshold for disk usage (in percentage)
$threshold = 90

# Create an array to store the results
$results = @()

try {
    # Get disk information for all drives
    $diskInfo = Get-WmiObject -Class Win32_LogicalDisk | Where-Object { $_.DriveType -eq 3 }

    # Check if disk information is available
    if ($diskInfo) {
        foreach ($disk in $diskInfo) {
            # Calculate disk usage percentage
            $usedSpace = $disk.Size - $disk.FreeSpace
            $totalSpace = $disk.Size
            $usagePercentage = [math]::Round(($usedSpace / $totalSpace) * 100, 2)

            # Check if disk usage exceeds the threshold
            $status = if ($usagePercentage -ge $threshold) { "Threshold exceeded!" } else { "Below threshold." }

            # Add the result to the array
            $results += New-Object PSObject -Property @{
                Drive = $disk.DeviceID
                UsagePercentage = $usagePercentage
                Status = $status
            }
        }
    } else {
        Write-Warning "Disk information is not available."
    }
} catch {
    Write-Error "An error occurred while checking disk usage: $_"
}

# Output the results in a tabular format
$results | Format-Table -AutoSize

# Save this script as "disk_monitoring.ps1"
# Run the script periodically using Task Scheduler or any other automation tool.