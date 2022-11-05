
const tBody = document.getElementById('corpoCarrinho');
const tFav = document.getElementById('corpoFavorito');
const tVendido = document.getElementById('maisVendidos');
const subtotal = document.querySelector(".subtotalc");




function inicializarCursos() { //adiciona ao site cursos dinamicamente
    var containerCursos = document.getElementById('card');
    cursos.map((val) => {
        containerCursos.innerHTML += `
                <div class="info-card">
                    <img src="`+ val.imgSrc + `" class="imagen-curso u-full-width">
                    <h4>`+ val.titulo + `</h4>
                    <p>`+ val.autor + `</p>
                    <img src="img/estrelas.png">
                    <p>Preço<span class="u-pull-right ">Oferta</span></p>
                    <p class="preco">€ `+ val.preco + `<span class="u-pull-right ">€ ` + val.promocao + `</span></p>
                    <a href="#"><img src="img/heart.png"  id="img-carrinho" onclick="adicionar_favorito(`+ val.isbn + `)"></a>
                    <a href="#" class="u-full-width button-primary button input adicionar-carrinho"
                    data-id="1" key="`+ val.isbn + `" onclick="adicionar_carrinho(` + val.isbn + `);" id="incart">Adicionar ao Carrinho</a>
                    
                </div>
        `;
    })
}
inicializarCursos();



let carrinho = JSON.parse(localStorage.getItem('itens')) || []; //recebe cursos escolhidos
atualizarcarrinho();


function adicionar_carrinho(isbn) { //adiciona itens ao carrinho
    if (carrinho.some((item) => item.isbn === isbn)) {
        mudarQuantidade("plus", isbn);
    } else {
        const item = cursos.find((curso) => curso.isbn === isbn);
        carrinho.push({ ...item, qtd: 1, });
    }
    localStorage.setItem('itens', JSON.stringify(carrinho));
    atualizarcarrinho();
}

function conteudoCarrinho() { //cria itens no carrinho

    if (carrinho != null) {
        let tr = '';
        carrinho.map(item => {
            tr += `
            <div class="curso-single">
            <img src="`+ item.imgSrc + `" class="imagen-curso u-full-width">
            <h4>`+ item.titulo + `</h4>
            <p>`+ item.autor + `</p>
            <h4 class="preco">Preço Final<span class="u-pull-right ">€ ` + item.promocao + `</span></h4>
            <h4 class="preco">Qtd<span class="u-pull-right ">x  `+ item.qtd + `</span></h4>
            
            </div>
            <div class="unidades">
                <div class="btn minus" onclick="mudarQuantidade('minus', ${item.isbn})">-</div>
                <div class="btn plus" onclick="mudarQuantidade('plus', ${item.isbn})">+</div>           
            </div>
        `})
        tBody.innerHTML = tr;
    }
}

function limpa() { //esvazia o carrinho
    const arr = JSON.parse(localStorage.getItem('itens'));
    localStorage.clear();
    carrinho.length = 0;
    if (arr != null) {
        let tr = '';
        arr.map(item => {
            tr += ` `
        })
        tBody.innerHTML = tr;
    }
    carrinhoSubtotal();
}





let favorito = [];//recebe cursos favoritos

function adicionar_favorito(isbn) { //adiciona itens ao array favoritos

    const itemf = cursos.find((curso) => curso.isbn === isbn);
    favorito.push(itemf);
    localStorage.setItem('favs', JSON.stringify(favorito));
    addFavorito();
}

function addFavorito() { //adiciona item ao favorito com botão para adicionar ao carrinho
    const arrf = JSON.parse(localStorage.getItem('favs'));

    if (arrf != null) {
        let trf = '';
        arrf.map(itemf => {
            trf += ` 
            <div class="curso-single">
            <img src="`+ itemf.imgSrc + `" class="imagen-curso u-full-width">
            <h4>`+ itemf.titulo + `</h4>
            <p>`+ itemf.autor + `</p>
            <p class="preco">Preço<span class="u-pull-right ">Oferta</span></p>
            <h4 class="preco">€  `+ itemf.preco + `<span class="u-pull-right ">€  ` + itemf.promocao + `</span></h4>
            <a href="#" class="u-full-width button-primary button input adicionar-carrinho"
            data-id="1" key="`+ itemf.isbn + `" onclick="adicionar_carrinho(` + itemf.isbn + `);" id="incart">Adicionar ao Carrinho</a>
            </div>
            `})
        tFav.innerHTML = trf;
    }
}

function limpaf() { //esvazia o carrinho
    const arrf = JSON.parse(localStorage.getItem('itens'));
    favorito.length = 0;
    if (arrf != null) {
        let trf = '';
        arrf.map(item => {
            trf += ` `
        })
        tFav.innerHTML = trf;
    }


}


function mudarQuantidade(action, isbn) { //muda quantidade de itens no carrinho
    carrinho = carrinho.map((item) => {
        let qtd = item.qtd;

        if (item.isbn === isbn) {
            if (action === "minus") {
                qtd--;
            } else if (action === "plus") {
                qtd++;
            }
        }

        return {
            ...item,
            qtd,
        };
    });

    atualizarcarrinho();
}

function atualizarcarrinho() {
    conteudoCarrinho();
    carrinhoSubtotal();
    
    localStorage.setItem('itens', JSON.stringify(carrinho));
    
}

function carrinhoSubtotal() { //renderiza e calcula valor no carrinho
    let totalPreco = 0,
        totalItems = 0;

    carrinho.forEach((item) => {
        totalPreco += item.promocao * item.qtd;
        totalItems += item.qtd;

    });
    subtotal.innerHTML = `Subtotal (${totalItems} items): € ${totalPreco.toFixed(2)}`;

}



function checkout() { //esvazia o carrinho e adiciona ao mais vendidos
    const arrv = JSON.parse(localStorage.getItem('itens'));
    /*arrv.sort(function(a,b) {
        return a.qtd > b.qtd;
    });*/

       if (arrv != null) {
        let trv = '';
        arrv.map(itemv => {
            trv += ` 
            <div class="curso-single">
            <img src="`+ itemv.imgSrc + `" class="imagen-curso u-full-width">
            <h4>`+ itemv.titulo + `</h4>
            <p>`+ itemv.autor + `</p>
            <p class="preco">Preço<span class="u-pull-right ">Oferta</span></p>
            <h4 class="preco">€  `+ itemv.preco + `<span class="u-pull-right ">€  ` + itemv.promocao + `</span></h4>
            <a href="#" class="u-full-width button-primary button input adicionar-carrinho"
            data-id="1" key="`+ itemv.isbn + `" onclick="adicionar_carrinho(` + itemv.isbn + `);" id="incart">Adicionar ao Carrinho</a>
            </div>
            `})
        tVendido.innerHTML = trv;
    }
    limpa();

} 




