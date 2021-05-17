## WinFormHosting
WinForm for Microsoft.Extensions.Hosting

### Nuget
```
<PackageReference Include="WinFormHosting" Version="1.0.0" />
```

### 如何使用
public static void Main(string[] args)
{
	CreateHostBuilder(args).Build().Run();
}

public static IHostBuilder CreateHostBuilder(string[] args) =>
	Host.CreateDefaultBuilder(args)
		.UseWinForm<MainForm>()
		.UseWinFormHostLifetime()
		.ConfigureServices(services =>
		{
			services.AddScoped<ScopeService>();
			services.AddSingleton<SingletonService>();
		});