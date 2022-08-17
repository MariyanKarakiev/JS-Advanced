function split(text) {

    let words = text.match(/\b\w+\b/g);

    console.log(words.join(', ').toUpperCase());
}

split('Hi')