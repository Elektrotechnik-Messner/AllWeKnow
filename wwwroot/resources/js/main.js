function delay(time) {
    return new Promise((resolve) =>
        setTimeout(resolve, time)
    ); /* delay(500).then(() => (do the code here)); */
}

document.addEventListener("scroll", (event) => {
    var top = window.scrollY || document.documentElement.scrollTop;
    var body = document.body;
    var nav = document.querySelector("nav.navbar");

    if (top > 384) {
        document.body.classList.add("scrolled");
        nav.classList.add("shadow");
    } else {
        document.body.classList.remove("scrolled");
        nav.classList.remove("shadow");
    }
});

window.js = {
    textEditor: {
        create: function (id) {
            ClassicEditor.create(document.getElementById(id), {
                toolbar: {
                    items: [
                        "undo",
                        "redo",
                        "heading",
                        "|",
                        "fontColor",
                        "fontBackgroundColor",
                        "fontFamily",
                        "bold",
                        "italic",
                        "underline",
                        "link",
                        "|",
                        "outdent",
                        "indent",
                        "bulletedList",
                        "numberedList",
                        "|",
                        "imageInsert",
                        "mediaEmbed",
                        "insertTable",
                        "blockQuote",
                        "superscript",
                        "subscript",
                        "specialCharacters",
                        "|",
                        "findAndReplace",
                        "removeFormat",
                    ],
                },
            }).catch((error) => {
                console.error(error);
            });
        },
        get: function (id)
        {
            let editor = document.getElementById(id).ckeditorInstance;
            return editor.getData();
        },
        set: function (id, data)
        {
            let editor = document.getElementById(id).ckeditorInstance;
            editor.setData(data);
        }
    }
}