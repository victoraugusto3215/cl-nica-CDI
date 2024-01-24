# Clínica CDI

## Estruturas do Programa

O software foi desenvolvido para atender às necessidades de uma clínica, focando nos pacientes, atendimentos e procedimentos. A estrutura do programa é modular, com cada funcionalidade organizada em classes distintas, proporcionando uma clara separação de responsabilidades.

### Paciente

- Representa um paciente e suas informações pessoais, como nome, data de nascimento, sexo e CPF.
- Utiliza métodos GET/SET para obtenção e inserção de informações.

### Procedimento

- Apresenta detalhes de um procedimento, como nome, código e duração.
- Emprega métodos GET/SET para manipular essas informações.

### Atendimento

- Representa um atendimento médico associado a um paciente e a um procedimento específico, incluindo a data de realização.
- Implementa métodos GET/SET para gerenciar informações relacionadas.

## Classes Gerenciadoras

### GerenciarPaciente

- Responsável pelo gerenciamento de pacientes, mantendo uma lista para armazenamento das instâncias de Paciente.
- Contém métodos para cadastrar novos pacientes, listar pacientes e buscar pacientes com base em critérios específicos.
- O método de cadastro solicita informações, valida os dados usando estruturas condicionais e faz a chamada do método "Buscar" para verificar se o paciente já está cadastrado.

### GerenciarProcedimento

- Encarregado do gerenciamento de procedimentos, utilizando uma Lista para armazenar instâncias de Procedimento.
- Inclui métodos para cadastrar, listar, buscar procedimentos, contar a quantidade realizada em um período e calcular a duração dos procedimentos realizados durante o período.
- Valida se um procedimento pode ser realizado com base nas exigências necessárias.

### GerenciarAtendimento

- Responsável pelo gerenciamento de atendimentos, mantendo uma lista para armazenar instâncias de atendimento.
- Contém métodos para cadastrar novos atendimentos, listar atendimentos e buscar atendimentos por data.
- Realiza verificações, como a busca se o paciente realizou procedimentos específicos nos últimos 3 meses.

## Menu Interativo

O arquivo principal, "Program.cs", apresenta um menu interativo que elenca as funcionalidades principais (Paciente, Atendimento e Procedimento). Cada opção do menu redireciona para a classe responsável por aquela funcionalidade. Todas as classes gerenciadoras possuem métodos de menu que representam as opções específicas daquela classe.
