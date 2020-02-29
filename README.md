# rh
Projeto Curso C# Meta

Exercício de lista.

Você vai criar um sistema de RH de uma empresa.

Esse sistema, precisa de alguns dados dos funcionários, como:
   * Nome
   * Data de Nascimento (DateTime)
   * CPF (com validação real de CPF)
   * Sexo
   * Nacionalidade 
   * Salário 
   * Cargo
   * Status do funcionário na empresa (trabalhando ou desligado)

Será possível fazer algumas alterações nos dados do funcionário, como:
   * Alterar Salário (requer também alteração de cargo)
   * Desligar funcionário.

O sistema também permite ver relatórios.
Os relatórios são:
   * Ver folha de pagamento da empresa 
            * Esse relatório mostrará cada funcionário e o salário dele sem imposto e com imposto (imposto é o cálculo de 55% do salário). No final, mostrará o total da folha da empresa com e sem imposto. Ex:
1 ==> Filipi ==> 10000 ==> 15500
2 ==> Lucas ==> 12000 ==> 18600

Total sem imposto ==> 22000
Total com imposto ==> 34100

    * Ver salário por sexo. Ex: O sexo Masculino da sua empresa recebe 7500 e o sexo feminino 8200
    * Buscar o funcionário mais velho da empresa
    * Buscar o funcionário mais novo da empresa
    * Buscar todos os funcionários ordenados pela idade.
     * Buscar todos os funcionários pela nacionalidade 
      
Obs: funcionários desligados não recebem salários mas devem aparecer nas pesquisas.
