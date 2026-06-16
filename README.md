# 🚀 SpaceBoy: Aventuras Além do Infinito

## 📖 Descrição do Jogo

**SpaceBoy: Aventuras Além do Infinito** é um jogo de plataforma 2D desenvolvido na Unity, onde o jogador controla um astronauta explorando diferentes ambientes espaciais em busca da saída de cada fase.

Ao longo da jornada, o jogador deve coletar moedas, evitar obstáculos e inimigos, encontrar chaves, acionar mecanismos e utilizar suas habilidades de movimentação para superar desafios cada vez mais complexos.

O objetivo é completar todas as fases e alcançar a tela de vitória final.

---

## 🎮 Mecânicas do Jogo

O jogo possui as seguintes mecânicas:

### Movimentação

* Andar para esquerda e direita.
* Pulo simples.
* Pulo duplo (double jump).

### Sistema de Vidas

* O jogador inicia com 3 vidas.
* Ao sofrer dano ou cair do cenário, perde uma vida.
* Quando as vidas chegam a zero, o jogo exibe a tela de Game Over.

### Coleta de Moedas

* Moedas espalhadas pelo cenário podem ser coletadas.
* O total coletado é exibido na HUD.

### Sistema de Checkpoint

* O progresso das moedas pode ser salvo ao inicio de cada fase.
* Ao perder uma vida, o jogador retorna mantendo apenas as moedas registradas no começo da fase.

### Cronômetro

* Toda fase possui um limite de tempo.
* Caso o tempo chegue a zero, ocorre Game Over.

### Chaves e Portas

* As fases exigem encontrar um keycard.
* A porta de saída só pode ser utilizada após a obtenção dessa keycard.

### Botões e Alçapões

* Algumas áreas possuem botões acionáveis.
* Ao pressionar um botão, o campo de força é desligado, permitindo o acesso a novas regiões do mapa.

### Escalada por Aderência

* O personagem possui a capacidade de se aderir a determinadas superfícies (Grounds).
* Enquanto aderido, pode subir e escalar paredes ou estruturas específicas, funcionando como uma mecânica de escalada.
* Essa habilidade é utilizada para alcançar áreas elevadas e resolver desafios de exploração.S

### Progressão de Dificuldade

* As fases foram projetadas para aumentar gradativamente a dificuldade.
* Novos obstáculos e desafios são introduzidos ao longo do jogo.

---

## 🕹️ Controles

| Tecla                                       | Ação                    |
| ------------------------------------------- | ----------------------- |
| A / ←                                       | Mover para esquerda     |
| D / →                                       | Mover para direita      |
| Espaço                                      | Pular                   |
| Espaço (no ar)                              | Pulo Duplo              |
| Escalar                                     | Pular enquanto grudado  |

---

## 🖥️ Tecnologias Utilizadas

* Unity 6
* C#
* TextMesh Pro
* Sistema de Física 2D da Unity
* Animator Controller
* Sistema de UI da Unity

---

## 🎨 Recursos Visuais

O projeto utiliza:

* Sprites em Pixel Art.
* Animações 2D.
* Interface HUD personalizada.
* Telas de Menu, Vitória e Game Over.
* Cenários espaciais temáticos.

---

## 🔊 Recursos Sonoros

O jogo foi desenvolvido com suporte para:

* Música de fundo.
* Efeitos sonoros de coleta.
* Sons de interação.
* Feedback sonoro para ações do jogador.

---

## ▶️ Como Executar

### Pelo Executável

1. Acesse a pasta do jogo.
2. Execute o arquivo:

SpaceBoy.exe

3. Aguarde o carregamento do menu principal.
4. Clique em **Jogar** para iniciar.

### Pelo Projeto Unity

1. Abra o projeto na Unity 6.
2. Abra a cena:

MainMenu

3. Clique em **Play** para iniciar.

---

## 📂 Estrutura de Fases

* Tela do Menu (MainMenu)
* Fase 1
* Fase 2
* Fase 3
* Fase 4
* Fase 5
* Tela de Vitória (YouWin)
* Tela de Derrota (GameOver)

---

## 👨‍💻 Desenvolvedor

Projeto desenvolvido como atividade acadêmica para a disciplina de Desenvolvimento de Jogos Digitais utilizando Unity e C#.
Aluno: Lucas Ribeiro Soares
