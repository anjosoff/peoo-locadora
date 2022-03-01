using System;
class Locadora{
  private string nome;
  public Locadora(string nome){
    this.nome=nome;
    
  }
  public void SetNome(string nome){
    this.nome=nome;
  }
  public string GetNome(){
    return nome;
  }
  public override string ToString(){
    return $"{nome}";
  }
}