# template-dotnetcore-application

## Solution Architecture

```
{SolutionName}.Api
{SolutionName}.Domain
{SolutionName}.Infrastructure
```

### `Domain`
---

Na camada de **Domain** se encontra o Core da solucao do problema que a aplicacao esta proposta a resolver, contendo principalmente toda a regra de negocio.

#### `Domain/DependencyInjection`

Nesta pasta teremos as classes responsaveis por configurar o **DI**.

```c#

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<I{ServiceName}Service, {ServiceName}Service>();
            return services;
        }
    }
}

```

#### `Domain/Dtos` - Data Transfer Object's
---

As `Dto's` sao responsaveis por trafegar dados de uma camada para outra, podendo assim ter apenas os campos que fazem sentido para a nossa implementacao.
Como padrao de nomenclatura, as nossas classes de Dto sempre terminarao com esse prefixo e serao seladas.

```c# 
public sealed class {ClassName}Dto {}
```

- [Martin Fowler - Data Transfer Object](https://martinfowler.com/eaaCatalog/dataTransferObject.html)
- [MSDN - Data Transfer Object](https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff649585(v=pandp.10)?redirectedfrom=MSDN)


#### `Domain/Services`
---

Os _servicos_ sao responsaveis por incapsular toda a regra de negocio que deve ser empregada a solucao.
Toda classe de servico deve terminar com o prefixo _Service_, ser selada e ter sua interface.

```c# 
public sealed class {ClassName}Service : I{ClassName}Service {}
```

#### `Domain/Gateways`
---

Na camada de dominio temos apenas as interfaces de nossos gateways, para serem injetadas conforme necessario em nossos servicos.

```c# 
public interface {GatewayName}Api {}
```

### `Infrastructure`
---

Na camada de **Infrastructure** temos todas implementacoes para recursos externos em que nossa aplicacao depende para alcancar seus objetivos.
A camada de **Infrastructure** depende da camada de **Domain** diretamente via dependencia de projeto.

#### `Infrastructure/DependencyInjection`

Nesta pasta teremos as classes responsaveis por configurar o **DI**.

```c#

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddGateways(this IServiceCollection services)
        {
            services.AddHttpClient<I{GatewayName}Api, {GatewayName}Api>(client =>
            {
                client.BaseAddress = new Uri("https://external.api/v1/");
            });

            return services;
        }
    }
}

```

- [Use IHttpClientFactory to implement resilient HTTP requests](https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)

#### `Infrastructure/Gateways`
---

Os _Gateways_ sao classes responsaveis por implementar as chamadas para Api's externas e cada Api externa deve ser implementada em um gateway separado.
Toda classe de gateway deve terminar com o prefixo _Api_, ser selada e implementar sua interface que deve estar na camada de **Domain**.

```c# 
public sealed class {GatewayName}Api : {SolutionName}.Domain.Gateways.I{GatewayName}Api {}
```

