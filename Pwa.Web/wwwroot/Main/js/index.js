let sliderBoxContent = document.querySelectorAll(".slider_tab_item");
let btnTabCustom = document.querySelectorAll(".btn_custom_tab_slider");

var swiper = new Swiper(".the_best_slider", {
    slidesPerView: 4,
    spaceBetween: 16,
    slidesPerGroup: 1,
    loop: true,
    loopFillGroupWithBlank: true,
    navigation: {
        nextEl: ".swiper-button-prev-the_best_slider",
        prevEl: ".swiper-button-next-the_best_slider",
    },
    breakpoints: {
        992: {
            slidesPerView: 4,
            spaceBetween: 16,
        },
        768: {
            slidesPerView: 3,
            spaceBetween: 16,
        },

        500: {
            slidesPerView: 2,
            spaceBetween: 20,
        },
        280: {
            slidesPerView: 1,
            spaceBetween: 20,
        },
    },
});

var swiper = new Swiper(".game_slider", {
    slidesPerView: 1,
    spaceBetween: 0,
    slidesPerGroup: 1,
    loop: true,
    loopFillGroupWithBlank: true,
    navigation: {
        nextEl: ".swiper-button-prev-game_slider",
        prevEl: ".swiper-button-next-game_slider",
    },
    breakpoints: {
        768: {
            slidesPerView: 2,
            spaceBetween: 46,
        },
    },
});

var swiper = new Swiper(".most_veiw_slider", {
    slidesPerView: 4,
    spaceBetween: 18,
    slidesPerGroup: 1,
    loop: true,
    loopFillGroupWithBlank: true,
    breakpoints: {
        992: {
            slidesPerView: 4,
            spaceBetween: 18,
        },
        768: {
            slidesPerView: 3,
            spaceBetween: 18,
        },

        500: {
            slidesPerView: 2,
            spaceBetween: 18,
        },

        280: {
            slidesPerView: 1,
            spaceBetween: 20,
        },
    },
});

var swiper = new Swiper(".app_category_slider", {
    slidesPerView: 2,
    spaceBetween: 18,
    slidesPerGroup: 1,
    navigation: {
        nextEl: ".swiper-button-prev_slider_tab",
        prevEl: ".swiper-button-next_slider_tab",
    },
    breakpoints: {
        1200: {
            slidesPerView: 7,
        },
        992: {
            slidesPerView: 5,
            spaceBetween: 20,
        },
        992: {
            slidesPerView: 4,
            spaceBetween: 20,
        },
        430: {
            slidesPerView: 3,
            spaceBetween: 20,
        },
    },
});

btnTabCustom.forEach((item) => {
    item.addEventListener("click", () => {
        changeSliderContent(item.getAttribute("data-slidernumber"));
        btnTabCustom.forEach((element) => {
            element.classList.remove("active");
        });
        item.classList.add("active");
    });
});
changeSliderContent(1)
function changeSliderContent(number) {
    console.log(number);
    sliderBoxContent.forEach((item) => {
        item.classList.add("d-none");
    });

    sliderBoxContent[Number(number) - 1].classList.remove("d-none");
    var elementClass = '.app_category_tab_content_' + number;


    var swiper = new Swiper(elementClass, {
        slidesPerView: 4,
        spaceBetween: 18,
        slidesPerGroup: 1,
        loop: false,
        loopFillGroupWithBlank: false,
        breakpoints: {
            992: {
                slidesPerView: 4,
                spaceBetween: 18,
            },
            768: {
                slidesPerView: 3,
                spaceBetween: 18,
            },

            500: {
                slidesPerView: 2,
                spaceBetween: 18,
            },
            280: {
                slidesPerView: 1,
                spaceBetween: 0,
            },
        },
    });


}

window.addEventListener("scroll", () => {
    if (window.scrollY >= 100) {
        header.classList.add("header_bg");
    } else {
        header.classList.remove("header_bg");
    }
});




