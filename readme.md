# 🛡️ Realistic Traffic Simulator

This tool is a C#-based traffic simulator designed to help you test your website's anti-DDoS protections and rate-limiting capabilities. It sends realistic HTTP GET requests from randomized user-agents to mimic human-like web traffic.

> ⚠️ **Use responsibly. Only test domains you own or have permission to test.**
> Misuse of this tool can be illegal and against hosting provider policies.

---

## 🚀 Features

- ✅ Multi-threaded request simulation
- ✅ Randomised User Agents
- ✅ Mix of GET and POST requests

---

## 🧑‍💻 How to Use

### 🖥️ Requirements

- [.NET 6.0 or newer](https://dotnet.microsoft.com/download)
- Windows or any OS supported by .NET

### 🔧 Build & Run

```bash
dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true /p:SelfContained=true
```
