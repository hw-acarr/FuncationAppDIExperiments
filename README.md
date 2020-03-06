# STUF

Testing DI in an Azure Function App

## Notes

Transient objects are always different; a new instance is provided to every controller and every service.

Scoped objects are the same within a request, but different across different requests.

Singleton objects are the same for every object and every request.

## References

https://www.twilio.com/blog/draft-dependency-injection-in-azure-functions-with-csharp