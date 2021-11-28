//animação da barra de pesquisa

var BarraDeBusca  = document.querySelector(".search-container");

document.addEventListener( "click", function(event) {
    if(event.target.closet("#search")) {
        barraDeBusca.classList.add("searching");
        return
    }
    barraDeBusca.classList.Remove("searching");
})
//FIm da Animação da barra de pesquisa

//Pesquisar usuario/Posts 

let campoFiltro = document.querySelector("#buscar");

campoFiltro.addEventListener("input", function() {
    console.log(this.value);
    let post = document.querySelectorAll(".post-feed");
    let stories = Comment.querySelectorAll(".friends");

    if (campoFiltro.value.length != 0){
        for (let i = 0; i < posts.length; i++) {
            let post = posts[i];
            let postNome = post.querySelector(".nome-publicacao");
            let nome = postNome.textContent;

            var expressao = new RegExp(this.value, "i");
            if(!expressao.test(nome)) {
                post.classList.add("invisivel");
            } else {
                post.classList.remove("invisivel");
            }
        }

        for (let i = 0; i < stories.length; i++) {
            let story = stories[i];
            let storyNome = story.querySelector(".nome-stories");
            let nome = storyNome.textContent;

            if(!expressao.test(nome)) {
                story.classList.add("invisivel");
            } else {
                story.classList.remove("invisivel");
            }
        }
    } else {
        for (let i = 0; i < posts.length; i++) {
            let post = posts[i];
            post.classList.remove("invisivel");
            
        }

        for (let i = 0; i < stories.length; i++) {
            let story = stories[i];
            story.classList.remove("invisivel");
            
        }
    }
});