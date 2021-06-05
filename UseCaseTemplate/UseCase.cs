using System;
using System.Collections.Generic;
using System.Text;

namespace $rootnamespace$
{
  public class UseCase : I$fileinputname$
  {
    private readonly IOutputPort<$fileinputname$Response> outputPort;
    private readonly INotifications notifications;
    private readonly ILogRepository logRepository;

    public UseCase(IOutputPort<$fileinputname$Response> outputPort,INotifications notifications, ILogRepository logRepository)
    {
      this.outputPort = outputPort;
      this.notifications = notifications;
      this.logRepository = logRepository;
    }
    public override void Execute($fileinputname$Request request)
    {
      try
      {
        InitialHandler.ProcessRequest(request);
      }
      catch (Exception ex)
      {
        var message = $"Occurring an error to get segments exempt list. Error: {ex.InnerException?.Message ?? ex.Message}, stacktrace: {ex.StackTrace}";
        notifications.AddExceptionNotification(ex.Message, ex.StackTrace);
        request.AddErrorLog(message);
      }
      finally
      {
        logRepository.Add(request.Logs);
        BuildOutput(request);
      }
    }

    private void BuildOutput($fileinputname$Request request)
    {
      if (notifications.HasNotifications)
        outputPort.Error("");
      else
        outputPort.Standard(request.Response);
    }
  }
}
