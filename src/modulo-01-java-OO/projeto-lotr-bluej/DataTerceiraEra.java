public class DataTerceiraEra {
    private int dia, mes, ano;
    
    public DataTerceiraEra(int dia, int mes, int ano) {
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;
    }
    
    public int getDia() {
        return this.dia;
    }
    
    public int getMes() {
        return this.mes;
    }
    
    public int getAno() {
        return this.ano;
    }
    
    public boolean ehBissexto() {
        // São bissextos todos os anos múltiplos de 400, p.ex: 1600, 2000, 2400, 2800...
        return this.ano % 400 == 0 || this.ano % 4 == 0 && this.ano % 100 != 0;
    }
}

























