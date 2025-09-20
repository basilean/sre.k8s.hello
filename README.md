# sre.k8s.hello

## Build
Compile
```bash
dotnet publish -c Release -r linux-x64 --self-contained true /p:PublishAot=true
```

## Run
```bash
bin/Release/net8.0/linux-x64/publish/Sre.K8s.Hello
```

## Probes
Check Probes
```bash
curl http://localhost:5000/readyz
```

Make it Fail
```bash
curl http://localhost:5000/fail
```

## Telemetry
To get telemetry, export these variables first and run:
```bash
OTEL_EXPORTER_OTLP_INSECURE=true
OTEL_EXPORTER_OTLP_ENDPOINT=http://localhost:4317
bin/Release/net8.0/linux-x64/publish/Sre.K8s.Hello
```

Remember to get a collector running.
```bash
otelcol --config otel.conf
```

With a working configuration.
```bash
receivers:
  otlp:
    protocols:
      grpc:
      http:

exporters:
  debug:
    verbosity: normal

service:
  pipelines:
    traces:
      receivers: [otlp]
      exporters: [debug]

    metrics:
      receivers: [otlp]
      exporters: [debug]

    logs:
      receivers: [otlp]
      exporters: [debug]
```

## Swagger
```
http://localhost:5000/swagger/index.html
```