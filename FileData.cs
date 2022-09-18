namespace DotnetWorker
{
    public class FileData : IFileData
    {
        public async Task CreateFile(string path)
        {
            using (var sw = new StreamWriter(path))
            {
                await Task.Delay(5000);
                await sw.WriteAsync("Hello word");
            }
        }
    }
}
