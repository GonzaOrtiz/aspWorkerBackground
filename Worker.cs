using DotnetWorker;

namespace worker
{
    //Clase worker debe heredar de BackgroundService
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IFileData _fileData;
        private string _path = Directory.GetCurrentDirectory() + @"\Files\";
        private int _count = 0;
        public Worker(ILogger<Worker> logger, IFileData fileData)
        {
            _logger = logger;
            _fileData = fileData;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //escribimos la tarea que corre en segundo plano
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await _fileData.CreateFile($"{_path}{_count++}.txt");
            }
        }
    }
}