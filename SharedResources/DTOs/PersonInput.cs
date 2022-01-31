namespace SharedResources.DTOs
{
#if ADJUST_DTOS_TO_HC12
    //CANNOT be defined like this:
    //  public sealed record PersonInput(string[]? OnlyIncludeFirstNames);
    //because otherwise the following error occurs
    //  {
    //    "errors": [
    //      {
    //        "message": "Unexpected Execution Error",
    //        "locations": [
    //          {
    //            "line": 10,
    //            "column": 3
    //          }
    //        ],
    //        "path": [
    //          "people"
    //        ],
    //        "extensions": {
    //          "message": "Cannot dynamically create an instance of type 'SharedResources.DTOs.PersonInput'. Reason: No parameterless constructor defined.",
    //          "stackTrace": "   at System.RuntimeType.ActivatorCache..ctor(RuntimeType rt)\r\n   at System.RuntimeType.CreateInstanceDefaultCtor(Boolean publicOnly, Boolean wrapExceptions)\r\n   at System.Activator.CreateInstance(Type type, Boolean nonPublic, Boolean wrapExceptions)\r\n   at HotChocolate.Utilities.DictionaryToObjectConverter.VisitObject(IReadOnlyDictionary`2 dictionary, ConverterContext context)\r\n   at HotChocolate.Utilities.DictionaryVisitor`1.Visit(Object value, TContext context)\r\n   at HotChocolate.Utilities.DictionaryToObjectConverter.Convert(Object from, Type to)\r\n   at HotChocolate.Types.InputParser.ConvertValue(Type requestedType, Object value)\r\n   at HotChocolate.Types.InputParser.ParseLiteral(IValueNode value, IInputFieldInfo field, Type targetType)\r\n   at HotChocolate.Execution.Processing.MiddlewareContext.CoerceArgumentValue[T](ArgumentValue argument)\r\n   at HotChocolate.Execution.Processing.MiddlewareContext.ArgumentValue[T](NameString name)\r\n   at lambda_method22(Closure , IResolverContext )\r\n   at HotChocolate.Types.Helpers.FieldMiddlewareCompiler.<>c__DisplayClass9_0.<<CreateResolverMiddleware>b__0>d.MoveNext()\r\n--- End of stack trace from previous location ---\r\n   at HotChocolate.Execution.Processing.Tasks.ResolverTask.ExecuteResolverPipelineAsync(CancellationToken cancellationToken)\r\n   at HotChocolate.Execution.Processing.Tasks.ResolverTask.TryExecuteAsync(CancellationToken cancellationToken)"
    //        }
    //      }
    //    ],
    //    "data": {
    //      "people": null
    //    }
    //  }

    public sealed record PersonInput
    {
        public string[]? OnlyIncludeFirstNames { get; set; }
    }
#else
    internal sealed record PersonInput(string[]? OnlyIncludeFirstNames);
#endif
}
