This project uses .NET 9.0, so in order to properly run, make sure all the correct versions of the following packets are installed:
Packets
├─ Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore (9.0.8)
├─ Microsoft.AspNetCore.OpenApi (9.0.7)
├─ Microsoft.EntityFrameworkCore.InMemory (9.0.8)
└─ Swashbuckle.AspNetCore (9.0.4)

Then, compile and go to https://localhost:8888/swagger/index.html to try out all the endpoints or, to try them out faster, check 
APIRestful.http and send requests from there!

If I had more time, I'd set this up on Azure and make a front-end out of Angular or React. With no designer, it probably would look bland, but it would be functional. Would surely add some actual security features and an User Database, connected to google, because I hate having to register an account for everything and anything, and i suppose others do too.

As requested, i didn't use an AI to create or develop this project for me. I did google for solutions on smaller errors that occurred.

That's all, folks!
