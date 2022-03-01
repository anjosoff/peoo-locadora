using System;
class Sistema{
  private static Veiculo[] veiculos = new Veiculo[10];
  private static int nVeiculo;
  public static void VeiculoInserir(Veiculo obj){ 
    //verifica vetor
    if(nVeiculo==veiculos.Length)
      Array.Resize(ref veiculos, 2*veiculos.Length);
    //interir
    veiculos[nVeiculo]=obj;
    //incrementar contador
    nVeiculo++;
  }
  public static Veiculo[] VeiculoListar(){
    //retornar objetos cadastrados
    Veiculo[] aux= new Veiculo[nVeiculo];
    Array.Copy(veiculos, aux, nVeiculo);
    return aux;
  }
}