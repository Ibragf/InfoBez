import psutil as psutil
import win32api


class FileSystemInfo:

    def FillDiskInfo(self):
        print()
        disks = psutil.disk_partitions()

        for disk in disks:
            print('Название:' + ' ' + disk.device)
            diskMarker=win32api.GetVolumeInformation(disk.device)
            print('Метка: ' + diskMarker[0])
            print('Тип файловой системы:' + ' ' +disk.fstype)
            print('Тип подключения:' + ' ' + disk.opts)
            usage=psutil.disk_usage(disk.device)
            print('Объем диска:'+' ' + str(round(usage.total/2**30,2)))
            print('Свободное место:' + ' ' + str(round(usage.free/2**30,2)))

            print('\n')

