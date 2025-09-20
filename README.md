# sre.k8s.hello

Compile
```bash
dotnet publish -c Release -r linux-x64 --self-contained true /p:PublishAot=true
```

Run
```bash
bin/Release/net8.0/linux-x64/publish/Sre.K8s.Hello
```

Check Probes
```bash
curl http://localhost:5000/readyz
```

Make it Fail
```bash
curl http://localhost:5000/fail
```
