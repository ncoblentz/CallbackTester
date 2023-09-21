# Callbacks Tester

What does it do?
* Logs requests to the console
* Provides prewired custom http responses/codes

How does it work?
1. `dotnet run``
2. Visit http://localhost:5000/api/Callback/200OK
2. Visit http://localhost:5000/api/Callback/Unauthorized403
2. Visit http://localhost:5000/api/Callback/Unauthorized401
3. Visit http://localhost:5000/api/Callback/api/Callback/UnauthorizedBasicAuth
3. Visit http://localhost:5000/api/Callback/api/Callback/UnauthorizedNTLMAuth
4. Visit http://localhost:5000/api/Callback/api/Callback/UnauthorizedNegotiateNTLMAuth
5. Visit http://localhost:5000/api/Callback/Redirect307?location=http://www.google.com
6. Visit http://localhost:5000/api/Callback/Redirect308?location=http://www.google.com
7. Visit http://localhost:5000/api/Callback/Redirect301?location=http://www.google.com
8. Visit http://localhost:5000/api/Callback/Redirect302?location=http://www.google.com
9.  Visit http://localhost:5000/api/Callback/CustomResponse?contenttype=text/plain (edit file `CustomResponse.txt`)
10. Visit http://localhost:5000/api/Callback/CustomResponseJson (edit file `CustomResponse.json`)
11. Visit http://localhost:5000/api/Callback/CustomResponseXML (edit file `CustomResponse.xml`)
12. Visit http://localhost:5000/api/Callback/CustomResponseHTML (edit file `CustomResponse.html`)
13. Visit http://localhost:5000/api/Callback/VariableStatusCode?_code=401
14. Edit the `CallbackController` to make it do something else