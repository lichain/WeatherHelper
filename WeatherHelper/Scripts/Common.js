/**
* Format date as a string
* @param date - a date object (usually "new Date();")
* @param format - a string format, eg. "DD-MM-YYYY"
*/
function dateFormat(date, format) {
    // Calculate date parts and replace instances in format string accordingly
    format = format.replace("DD", (date.getDate() < 10 ? '0' : '') + date.getDate()); // Pad with '0' if needed
    format = format.replace("MM", (date.getMonth() < 9 ? '0' : '') + (date.getMonth() + 1)); // Months are zero-based
    format = format.replace("YYYY", date.getFullYear());
    return format;
}

function getNow() {
    var now = new Date();
    var y = (now.getYear() + 1900);
    var m = (now.getMonth() + 1);
    var d = now.getDate();
    if (m < 10) m = "0" + m;
    if (d < 10) d = "0" + d;

    return y + "/" + m + "/" + d;
}

function getLastWeek() {
    var today = new Date();
    var ago7Day = new Date(Date.parse(new Date().toString()) - 86400000 * 6);
    var lastWeek = dateFormat(ago7Day, 'YYYY/MM/DD'); //“7天前”    
    return lastWeek;
}

function myBlockUI(){
	$.blockUI({ css: { 
            border: 'none', 
            padding: '15px', 
            backgroundColor: '#000', 
            '-webkit-border-radius': '10px', 
            '-moz-border-radius': '10px', 
            opacity: .5, 
            color: '#fff' 
        } });
}

function myUnBlcokUI(){
	$.unblockUI();
}

function ShowErrorMsgByBlockUI() {
    $.blockUI({
        message: $('div.growlUI'),
        fadeIn: 700,
        fadeOut: 700,
        timeout: 2000,
        showOverlay: false,
        centerY: false,
        css: {
            width: '350px',
            top: '10px',
            left: '',
            right: '10px',
            border: 'none',
            padding: '5px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .6,
            color: '#fff'
        }
    });
 }