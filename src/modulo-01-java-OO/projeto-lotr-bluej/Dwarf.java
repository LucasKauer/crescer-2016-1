public class Dwarf extends Personagem {
    private DataTerceiraEra dataNascimento;

    public Dwarf(String nome) {
        super(nome);
        this.vida = 110;
        this.nome = nome;
        this.dataNascimento = new DataTerceiraEra(1, 1, 1);
    }

    public Dwarf(String nome, DataTerceiraEra dataNascimento) {
        this(nome);
        this.dataNascimento = dataNascimento;
    }

    public void perderVida() {
        double numero = this.getNumeroSorte();

        if (numero < 0) {
            this.experiencia += 2;
        } else if (numero > 100) {

            int vidaAposFlechada = this.vida - 10;
            if (vidaAposFlechada == 0) {
                status = Status.MORTO;
            }

            if (vida > 0) {
                vida = vidaAposFlechada;
            }
        }
    }

    public DataTerceiraEra getDataNascimento() {
        return this.dataNascimento;
    }

    public double getNumeroSorte() {
        double resultado = 101.;

        if (dataNascimento.ehBissexto() && this.vida >= 80 && this.vida <= 90) {
            resultado *= -33.0;
        }

        if (!dataNascimento.ehBissexto() &&
        this.nome != null &&
        (this.nome.equals("Seixas") || this.nome.equals("Meireles"))) {
            resultado = resultado * 33 % 100;
        }

        return resultado;
    }
    
    public void tentarSorte() {
        double numero = getNumeroSorte();
        
        if (numero == -3333.0) {
            this.inventario.aumentar1000UnidadesPorItem();
        }
    }

    /*private void tirarVida() {
    this.vida -= 10;
    }*/

    // Declarar um objeto:
    // Dwarf gimli = null;

    // Criação (instanciação):
    // new Dwarf();
    // Dwarf d1 = new Dwarf();

}


