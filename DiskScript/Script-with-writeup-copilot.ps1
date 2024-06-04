<#
.SYNOPSIS
    Retrieves disk usage information for all logical disks.

.DESCRIPTION
    This script retrieves disk usage information for all logical disks on the system. It uses the Get-WmiObject cmdlet to query the Win32_LogicalDisk class and filters the results to include only disks with a DriveType of 3 (which represents local hard disks).

.PARAMETER None
    This script does not accept any parameters.

.OUTPUTS
    The script outputs disk usage information for each logical disk in a table format. The table includes the following columns:
    - DeviceID: The drive letter of the logical disk.
    - Size (GB): The total size of the logical disk in gigabytes.
    - Free Space (GB): The amount of free space on the logical disk in gigabytes.
    - Free Space (%): The percentage of free space on the logical disk.

.EXAMPLE
    PS C:\> .\Get-DiskUsage.ps1
    Retrieves and displays disk usage information for all logical disks on the system.

.NOTES
    - This script requires administrative privileges to run.
    - The script uses the Format-Table cmdlet to format the output as a table. You can modify the formatting options as needed.
#>

# Get the disk usage
try {
    $diskUsage = Get-WmiObject -Class Win32_LogicalDisk | Where-Object {$_.DriveType -eq 3} | 
        Select-Object DeviceID, 
        @{Name="Size (GB)";Expression={"{0:N1}" -f ($_.Size/1GB)}}, 
        @{Name="Free Space (GB)";Expression={"{0:N1}" -f ($_.FreeSpace/1GB)}}, 
        @{Name="Free Space (%)";Expression={"{0:P1}" -f (($_.FreeSpace/1GB) / ($_.Size/1GB))}}

    # Output the disk usage
    $diskUsage | Format-Table -AutoSize
}
catch {
    Write-Host "An error occurred while retrieving disk usage information: $_"
}
