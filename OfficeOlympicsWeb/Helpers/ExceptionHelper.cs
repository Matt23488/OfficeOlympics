using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.Helpers
{
    public static class ExceptionHelper
    {
        public static Exception GenerateException(ExceptionType type, Exception inner = null)
        {
            string message = "asldbvgniasiaseotrh";

            switch (type)
            {
                case ExceptionType.AccessViolationException:
                    return new AccessViolationException(message, inner);
                case ExceptionType.AggregateException:
                    return new AggregateException(message, inner);
                case ExceptionType.AppDomainUnloadedException:
                    return new AppDomainUnloadedException(message, inner);
                case ExceptionType.ApplicationException:
                    return new ApplicationException(message, inner);
                case ExceptionType.ArgumentException:
                    return new ArgumentException(message, inner);
                case ExceptionType.ArgumentNullException:
                    return new ArgumentNullException(message, inner);
                case ExceptionType.ArgumentOutOfRangeException:
                    return new ArgumentOutOfRangeException(message, inner);
                case ExceptionType.ArithmeticException:
                    return new ArithmeticException(message, inner);
                case ExceptionType.ArrayTypeMismatchException:
                    return new ArrayTypeMismatchException(message, inner);
                case ExceptionType.BadImageFormatException:
                    return new BadImageFormatException(message, inner);
                case ExceptionType.CannotUnloadAppDomainException:
                    return new CannotUnloadAppDomainException(message, inner);
                case ExceptionType.ContextMarshalException:
                    return new ContextMarshalException(message, inner);
                case ExceptionType.DataMisalignedException:
                    return new DataMisalignedException(message, inner);
                case ExceptionType.DivideByZeroException:
                    return new DivideByZeroException(message, inner);
                case ExceptionType.DllNotFoundException:
                    return new DllNotFoundException(message, inner);
                case ExceptionType.DuplicateWaitObjectException:
                    return new DuplicateWaitObjectException(message, inner);
                case ExceptionType.EntryPointNotFoundException:
                    return new EntryPointNotFoundException(message, inner);
                case ExceptionType.Exception:
                    return new Exception(message, inner);
                case ExceptionType.FieldAccessException:
                    return new FieldAccessException(message, inner);
                case ExceptionType.FormatException:
                    return new FormatException(message, inner);
                case ExceptionType.HttpCompileException:
                    return new HttpCompileException(message, inner);
                case ExceptionType.HttpUnhandledException:
                    return new HttpUnhandledException(message, inner);
                case ExceptionType.IndexOutOfRangeException:
                    return new IndexOutOfRangeException(message, inner);
                case ExceptionType.InsufficientMemoryException:
                    return new InsufficientMemoryException(message, inner);
                case ExceptionType.KeyNotFoundException:
                    return new KeyNotFoundException(message, inner);
                case ExceptionType.NotImplementedException:
                    return new NotImplementedException(message, inner);
                default:
                    return new NotSupportedException(message, inner);
            }
        }

        public enum ExceptionType
        {
            AccessViolationException = 0,
            AggregateException = 1,
            AppDomainUnloadedException = 2,
            ApplicationException = 3,
            ArgumentException = 4,
            ArgumentNullException = 5,
            ArgumentOutOfRangeException = 6,
            ArithmeticException = 7,
            ArrayTypeMismatchException = 8,
            BadImageFormatException = 9,
            CannotUnloadAppDomainException = 10,
            ContextMarshalException = 11,
            DataMisalignedException = 12,
            DivideByZeroException = 13,
            DllNotFoundException = 14,
            DuplicateWaitObjectException = 15,
            EntryPointNotFoundException = 16,
            Exception = 17,
            FieldAccessException = 18,
            FormatException = 19,
            HttpCompileException = 20,
            HttpUnhandledException = 21,
            IndexOutOfRangeException = 22,
            InsufficientMemoryException = 23,
            KeyNotFoundException = 24,
            NotImplementedException = 25
        }
    }
}