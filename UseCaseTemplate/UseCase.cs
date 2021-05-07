using System;
using System.Collections.Generic;
using System.Text;

namespace $rootnamespace$
{
     public class UseCase : UseCase<$fileinputname$UcRequest>, I$fileinputname$
    {
  private readonly IOutputPort<List<object>> outputPort;
  private readonly INotifications notifications;

  public UseCase(IOutputPort<List<object>> outputPort,
                  INotifications notifications)
  {

    //InitialHandler =

    this.outputPort = outputPort;
    this.notifications = notifications;
  }
  public override void Execute($fileinputname$UcRequest request)
  {
    try
    {
      InitialHandler.ProcessRequest(request);
    }
    catch (Exception ex)
    {
      notifications.AddExceptionNotification(ex.Message, ex.StackTrace);
    }
    finally
    {
      BuildOutput(request);
    }
  }

  private void BuildOutput($fileinputname$UcRequest request)
  {
    if (notifications.HasNotifications)
      ErrorOutput<IOutputPort<List<object>>, List<object>>(outputPort, notifications);
    else
      SuccessOutput(outputPort, request.Output);
  }
}
}
