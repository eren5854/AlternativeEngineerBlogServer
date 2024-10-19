using ED.Result;

namespace AlternativeEngineerBlogServer.Infrastructure.Services;
public sealed class FileSizeService
{
    private readonly string _imagesPath;
    private readonly string _profilePicturesPath;

    public FileSizeService(string webRootPath)
    {
        _imagesPath = Path.Combine(webRootPath, "Images");
        _profilePicturesPath = Path.Combine(webRootPath, "ProfilePictures");
    }

    public async Task<Result<long>> GetTotalSizeAsync()
    {
        long totalSize = 0;

        // Images klasöründeki dosyaların boyutunu ekle
        if (Directory.Exists(_imagesPath))
        {
            totalSize += await Task.Run(() => GetDirectorySize(_imagesPath));
        }

        // ProfilePictures klasöründeki dosyaların boyutunu ekle
        if (Directory.Exists(_profilePicturesPath))
        {
            totalSize += await Task.Run(() => GetDirectorySize(_profilePicturesPath));
        }

        return Result<long>.Succeed(totalSize);
    }

    private long GetDirectorySize(string directoryPath)
    {
        long size = 0;

        // Klasördeki dosyaları topla
        var files = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            FileInfo fileInfo = new FileInfo(file);
            size += fileInfo.Length; // Dosya boyutunu ekle
        }

        return size;
    }
}
