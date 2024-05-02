## Cofidis

Num contexto de incerteza económica e inflação, os portugueses enfrentam dificuldades financeiras
e necessitam de uma solução de micro-crédito inovadora e acessível para atender às suas
necessidades de curto prazo. Foste escolhido para integrares uma equipa de desenvolvimento de
uma plataforma de micro-crédito com a missão de desenvolver os serviços que suportam uma
interface de utilizador intuitiva.

Os serviços REST desenvolvidos em .net devem suportar um sistema de registo simplificado que
permita aos utilizadores acederem rapidamente à plataforma e solicitarem micro-créditos de forma
simples e direta.
Para simplificar este processo de registo e garantir a precisão das informações fornecidas, a API deve
comunicar com a Chave Móvel Digital que fornece automaticamente todas as informações
necessárias e pessoais para um determinado número de identificação fiscal (NIF).
Nota: o consumo deste serviço não deve ser real, sendo virtualizado (mock) para efeito de
demonstração.

Os micro-créditos são personalizados com limites de crédito adaptados às circunstâncias individuais
de cada cliente, podendo escolher o montante do empréstimo e o prazo que melhor se adequam às
suas necessidades.
Para simplificar o processo de determinação dos limites de crédito dos clientes, será desenvolvida
uma stored procedure que utilizará os seguintes critérios com base no rendimento mensal.

- Até 1000€ (Limite de crédito máximo: 1000€)
- Entre 1000€ e 2000€ (Limite de crédito máximo: 2000€)
- Acima de 2000€ (Limite de crédito máximo: 5000€)

Deve ser implementado um algoritmo de análise de risco que leve em consideração a situação
económica atual, bem como o histórico de crédito e comportamento financeiro do utilizador.
O algoritmo em C# deve calcular um índice de risco com base nas seguintes variáveis (taxa de
desemprego, inflação, histórico de crédito e dívidas do cliente) e determinar a concessão de crédito
ao cliente.
Pretende-se garantir a robustez e confiabilidade do código graças a testes unitários, devendo
abranger diferentes cenários possíveis, garantindo o funcionamento correto em diferentes condições.

Para cumprires esta missão, tens a liberdade de assumir os pressupostos necessários para o
desenvolvimento da API. Podes selecionar os detalhes e critérios de desenvolvimento que consideres
mais adequados para atender aos requisitos estabelecidos. O código que desenvolveres deve estar
pronto para ser executado utilizando o Visual Studio 2022 ou uma versão inferior. Quanto à base de
dados, basta forneceres o script da stored procedure desenvolvida para SQL Server.
