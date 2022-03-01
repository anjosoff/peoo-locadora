using System;
class Veiculo{
  private string modelo;
  private string placa;
  public Veiculo(string modelo, string placa){
    this.modelo=modelo;
    this.placa=placa;
    
  }
  public void SetModelo(string modelo){
    this.modelo=modelo;
  }public void SetPlaca(string placa){
    this.placa=placa;
  }
  public string GetPlaca(){
    return placa;
  }
  public string GetModelo(){
    return modelo;
  }
  public override string ToString(){
    return $"{modelo} - {placa}";
  }
}