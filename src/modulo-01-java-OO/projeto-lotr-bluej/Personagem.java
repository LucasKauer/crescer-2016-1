public abstract class Personagem {
    protected String nome;
    protected int experiencia;
    protected Inventario inventario = new Inventario();
    protected double vida;
    protected Status status = Status.VIVO;

    protected Personagem(String nome) {
        this.nome = nome;
    }

    public int getExperiencia() {
        return this.experiencia;
    }

    public String getNome() {
        return this.nome;
    }

    public Inventario getInventario() {
        return this.inventario;
    }

    public void adicionarItem(Item item) {
        this.inventario.adicionarItem(item);
    }

    public void perderItem(Item item) {
        this.inventario.removerItem(item);
    }

    public double getVida() {
        return this.vida;
    }

    public Status getStatus() {
        return this.status;
    }
}