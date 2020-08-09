//var xLinkFb = constParent + '/div[1]/div/div/div/div/div[1]/div/div[2]/div/div/span/div/a[1]';
//var xTenFb = constParent+'/div[1]/div/div/div/div/div[1]/div/div[2]/div/div/span/div/a[1]/span';
//var xTenFbDangBai = constParent +'/div[1]/div/div/div/div/div[3]/a';
//var xNgaydang = constParent +'/div[1]/div/div/div/div/div[3]/a/div/div[1]/span/div/span';
//var xNoiDung = constParent +'/div[1]/div/div/div/div/div[3]/a/div/div[1]/span/div';

//Chay code
var constParent = '/html/body/div[1]/div/div/div[1]/div[3]/div/div/div[1]/div/div[2]/div/div/div/div/div/div';
var anotherxPath = '/html/body/div[1]/div/div/div[1]/div[3]/div/div/div[1]/div/div[2]/div/div/div/div/div/div/div[1]/div/div/div[2]/div';

function getElementByXpath(path) {
    return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
}

var xrootE = getElementByXpath(constParent);
var lstArr = [];

for (var j = 0;  j < xrootE.childNodes.length; j++) { // lastChild is not the target

    
    if (getComputedStyle(xrootE.childNodes[j]).marginBottom !== '0px') {
        i= j+1
        var obj = {
            xLinkBaiDangfb, xTenFb, xLinkTenFb, xNgaydang, xNoiDung
        }
        var xLinkBaiDangfb = constParent + '/div[' + i + ']/div/div/div/div/div[1]/div/div[2]/div/div/span/div/a[1]';
        var xTenFb = constParent + '/div[' + i + ']/div/div/div/div/div[1]/div/div[2]/div/div/span/div/a[1]/span';
        var xLinkTenFb = constParent + '/div[' + i + ']/div/div/div/div/div[3]/a';
        var xNgaydang = constParent + '/div[' + i + ']/div/div/div/div/div[3]/a/div/div[1]/span/div/span';
        var xNoiDung = constParent + '/div[' + i + ']/div/div/div/div/div[3]/a/div/div[1]/span/div';
        if (getElementByXpath(xTenFb)) {
            obj.xTenFb = getElementByXpath(xTenFb).innerText;
        }

        var xNgayDangSpan = getElementByXpath(xNgaydang);
        var xNoiDungDiv = getElementByXpath(xNoiDung);
        if (xNgayDangSpan !== null || xNgayDangSpan !== 'undefined') {
            obj.xNgaydang = xNgayDangSpan.innerText;
        }
        if (xNoiDungDiv !== null) {
            xNoiDungDiv.removeChild(xNgayDangSpan);
            obj.xNoiDung = xNoiDungDiv.innerText;
        }
        if (getElementByXpath(xLinkBaiDangfb) !== null) {
            obj.xLinkBaiDangfb = getElementByXpath(xLinkBaiDangfb).getAttribute('href');
        }

        if (getElementByXpath(xLinkTenFb) !== null) {
            obj.xLinkTenFb = getElementByXpath(xLinkTenFb).getAttribute('href');
        }



        lstArr.push(obj);
    }

}

return lstArr;
//chay code


//var constParent = '/html/body/div[1]/div/div/div[1]/div[3]/div/div/div[1]/div/div[2]/div/div/div/div/div/div';

//function getElementByXpath(path) {
//    return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
//}

//var xrootE = getElementByXpath(constParent);
//var lstArr = [];

//    var obj = {
//        xLinkBaiDangfb, xTenFb, xLinkTenFb, xNgaydang, xNoiDung
//    }
//    var xLinkBaiDangfb = constParent + '/div[1]/div/div/div/div/div[1]/div/div[2]/div/div/span/div/a[1]';
//    var xTenFb = constParent + '/div[1]/div/div/div/div/div[1]/div/div[2]/div/div/span/div/a[1]/span';
//    var xLinkTenFb = constParent + '/div[1]/div/div/div/div/div[3]/a';
//    var xNgaydang = constParent + '/div[1]/div/div/div/div/div[3]/a/div/div[1]/span/div/span';
//    var xNoiDung = constParent + '/div[1]/div/div/div/div/div[3]/a/div/div[1]/span/div';
    
//        obj.xTenFb = getElementByXpath(xTenFb).innerText;


//    var xNgayDangSpan = getElementByXpath(xNgaydang);
//    var xNoiDungDiv = getElementByXpath(xNoiDung);
    
//        obj.xNgaydang = xNgayDangSpan.innerText;
 
//        xNoiDungDiv.removeChild(xNgayDangSpan);
//        obj.xNoiDung = xNoiDungDiv.innerText;
  
   
//        obj.xLinkBaiDangfb = getElementByXpath(xLinkBaiDangfb).getAttribute('href');
 

   
//        obj.xLinkTenFb = getElementByXpath(xLinkTenFb).getAttribute('href');




//    lstArr.push(obj);



// Select bai gan nhat
var e = getElementByXpath('/html/body/div[1]/div/div/div[1]/div[3]/div/div/div[1]/div[1]/div[1]/div/div[3]/div[1]/div[2]/div[2]/div[2]/div/div[2]/div/input');
e.click();

// Select the ngay dang
var k = getElementByXpath('/html/body/div[1]/div/div/div[1]/div[3]/div/div/div[1]/div[1]/div[1]/div/div[3]/div[1]/div[2]/div[2]/div[5]/div/div/div');
k.click();

// chon nam gan nhat
var l = getElementByXpath('/html/body/div[1]/div/div/div[1]/div[3]/div/div/div[2]/div/div/div[1]/div[1]/div/div/div/div/div[1]/div');
l.firstElementChild.click();