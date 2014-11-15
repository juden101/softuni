function replaceATag(str) {
    var regex = /(<a)(\shref=[a-z:/\.]+)(>)([a-zA-Z]+)(<\/a>)/;
    str = str.replace(regex, "[URL$2]$4[/URL]");

    return str;
}

console.log(replaceATag('<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>'));