/* 
 * Copyright (c) 2019, Firely (info@fire.ly) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-net-sdk/master/LICENSE
 */

using System;

namespace Hl7.Fhir.Utility
{
    public delegate void ExceptionNotificationHandler(object source, ExceptionNotification args);

    public interface IExceptionSource
    {
        ExceptionNotificationHandler ExceptionHandler { get; set; }
    }


    public class ExceptionNotification
    {
        public static ExceptionNotification Info(string message) => new ExceptionNotification(message, null, ExceptionSeverity.Info);

        public static ExceptionNotification Warning(Exception exception) => new ExceptionNotification(exception.Message, exception, ExceptionSeverity.Warning);

        public static ExceptionNotification Error(Exception exception) => new ExceptionNotification(exception.Message, exception, ExceptionSeverity.Error);

        private ExceptionNotification(string message, Exception exception, ExceptionSeverity severity)
        {
            Message = message;
            Exception = exception;
            Severity = severity;
        }

        public readonly string Message;
        public readonly Exception Exception;
        public readonly ExceptionSeverity Severity;
    }

    public enum ExceptionSeverity
    {
        Error,
        Warning,
        Info
    }
}
