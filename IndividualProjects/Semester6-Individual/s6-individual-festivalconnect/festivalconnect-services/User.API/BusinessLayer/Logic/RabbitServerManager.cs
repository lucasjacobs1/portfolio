namespace BusinessLayer.Logic
{
    using BusinessLayer.DTO.Responses;
    using BusinessLayer.Interfaces;
    using BusinessLayer.Models;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class RabbitServerManager : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RabbitServerManager> _logger;

        public RabbitServerManager(IServiceProvider serviceProvider, ILogger<RabbitServerManager> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = _serviceProvider.CreateScope();

            var messagingLogic = scope.ServiceProvider.GetRequiredService<IMessagingLogic>();

            messagingLogic.Subscribe<RabbitMessage<UserResponse>>(
                "CreateUser",
                "CreateUser",
                "CreateUser",
                async (message) => await HandleMessageAsync(message, async (logic, msg) => await logic.RegisterUser(msg)));

            messagingLogic.Subscribe<RabbitMessage<UserResponse>>(
                "DeleteUser",
                "DeleteUser",
                "DeleteUser",
                async (message) => await HandleMessageAsync(message, async (logic, msg) => await logic.DeleteUser(msg)));

            return Task.CompletedTask;
        }

        private async Task HandleMessageAsync(RabbitMessage<UserResponse> message, Func<IUserLogic, RabbitMessage<UserResponse>, Task> action)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var userLogic = scope.ServiceProvider.GetRequiredService<IUserLogic>();

                try
                {
                    await action(userLogic, message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing message");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
