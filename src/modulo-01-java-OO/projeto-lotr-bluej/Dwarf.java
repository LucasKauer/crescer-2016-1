public class Dwarf {
    private int vida = 110;
    private String nome;
    private Status status = Status.VIVO;
    private int experiencia;
    private Inventario inventario = new Inventario();
    private DataTerceiraEra dataNascimento;

    public Dwarf(String nome) {
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

    public void setNome(String novoNome) {
        nome = novoNome;
    }

    public String getNome() {
        return nome;
    }

    public int getVida() {
        return this.vida;
    }

    public Status getStatus() {
        return this.status;
    }

    public Inventario getInventario() {
        return this.inventario;
    }

    public int getExperiencia() {
        return this.experiencia;
    }

    public DataTerceiraEra getDataNascimento() {
        return this.dataNascimento;
    }

    public void adicionarItem(Item item) {
        this.inventario.adicionarItem(item);
    }

    public void perderItem(Item item) {
        this.inventario.removerItem(item);
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


