function getNow() {
    var now = new Date();
    var y = (now.getYear() + 1900);
    var m = (now.getMonth() + 1);
    var d = now.getDate();
    if (m < 10) m = "0" + m;
    if (d < 10) d = "0" + d;

    return y + "/" + m + "/" + d;
}
