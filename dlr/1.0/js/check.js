function check_uncheck(Val) {
    var ValChecked = Val.checked;
    var ValId = Val.id;
    var frm = document.forms[0];
    // Loop through all elements
    for (i = 0; i < frm.length; i++) {
        // Look for Header Template's Checkbox
        //As we have not other control other than checkbox we just check following statement
        if (this != null) {
            if (ValId.indexOf('CheckAll') != -1) {
                // Check if main checkbox is checked,
                // then select or deselect datagrid checkboxes
                if (ValChecked)
                    frm.elements[i].checked = true;
                else
                    frm.elements[i].checked = false;
            }
            else if (ValId.indexOf('deleteRec') != -1) {
                // Check if any of the checkboxes are not checked, and then uncheck top select all checkbox
                if (frm.elements[i].checked == false)
                    frm.elements[1].checked = false;
            }
        } // if
    } // for
} // function
function confirmMsg(frm) {
    var ValChecked = false;
    // loop through all elements
    for (i = 0; i < frm.length; i++) {
        // Look for our checkboxes only
        if (frm.elements[i].name.indexOf("deleteRec") != -1) {
            // If any are checked then confirm alert, otherwise nothing happens
            if (frm.elements[i].checked)
                ValChecked = true;
        }
    }
    if (ValChecked) {
        return confirm('你确定要删除选中的记录吗？ 删除后将不能恢复！');
    }
    else {
        window.alert('请先钩选想要删除的记录！');
        return false;
    }
}