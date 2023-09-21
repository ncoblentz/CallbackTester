# Callbacks Tester

What does it do?
* Logs requests to the console
* Provides prewired custom http responses/codes

How does it work?
1. clone this repository
1. `apt install dotnet-sdk-6.0`
2. `ufw allow 5000/tcp`
3. `ufw allow 5001/tcp`
4. `dotnet run`
5. Visit http://localhost:5000/api/Callback/200OK
6. Visit http://localhost:5000/api/Callback/Unauthorized403
7. Visit http://localhost:5000/api/Callback/Unauthorized401
8. Visit http://localhost:5000/api/Callback/api/Callback/UnauthorizedBasicAuth
9. Visit http://localhost:5000/api/Callback/api/Callback/UnauthorizedNTLMAuth
10. Visit http://localhost:5000/api/Callback/api/Callback/UnauthorizedNegotiateNTLMAuth
11. Visit http://localhost:5000/api/Callback/Redirect307?location=http://www.google.com
12. Visit http://localhost:5000/api/Callback/Redirect308?location=http://www.google.com
13. Visit http://localhost:5000/api/Callback/Redirect301?location=http://www.google.com
14. Visit http://localhost:5000/api/Callback/Redirect302?location=http://www.google.com
15. Visit http://localhost:5000/api/Callback/CustomResponse?contenttype=text/plain (edit file `CustomResponse.txt`)
16. Visit http://localhost:5000/api/Callback/CustomResponseJson (edit file `CustomResponse.json`)
17. Visit http://localhost:5000/api/Callback/CustomResponseXML (edit file `CustomResponse.xml`)
18. Visit http://localhost:5000/api/Callback/CustomResponseHTML (edit file `CustomResponse.html`)
19. Visit http://localhost:5000/api/Callback/VariableStatusCode?_code=401
20. Edit the `CallbackController` to make it do something else
21. `ufw delete allow 5000/tcp`
22. `ufw delete allow 5001/tcp`