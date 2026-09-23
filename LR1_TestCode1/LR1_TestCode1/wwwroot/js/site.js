const bouquets = [
    { name: "Sweet Peony", price: "1 290 ₴", mood: "ніжність" },
    { name: "Pink Dream", price: "1 490 ₴", mood: "романтика" },
    { name: "Blush Garden", price: "1 790 ₴", mood: "свято" }
];

function selectBouquet(name) {
    const bouquet = bouquets.find((item) => item.name === name);
    const result = document.getElementById("recommendationResult");
    if (!bouquet || !result) {
        return;
    }

    document.querySelectorAll(".bouquet-card").forEach((card) => {
        const title = card.querySelector("h3");
        card.classList.toggle("is-selected", title?.textContent === name);
    });

    result.textContent = `Обрано «${bouquet.name}» · ${bouquet.price} ♡`;
}

function recommendBouquet() {
    const bouquet = bouquets[Math.floor(Math.random() * bouquets.length)];
    selectBouquet(bouquet.name);

    const result = document.getElementById("recommendationResult");
    if (result) {
        result.textContent = `Рекомендація: «${bouquet.name}» — ${bouquet.mood}, ${bouquet.price} ♡`;
    }
}
