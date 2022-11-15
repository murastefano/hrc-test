# hrc-test
HCR tech challenge
<br />
WPF APP<br />
OK - At runtime it takes the size selected by the ComboBox<br />
OK - Initial cell values are a random integer from 1 to 9<br />
OK - Allows selection of an area of the available cells (1)<br />
NO - Allows copy/paste of the selected cells by using shortcuts: “Ctrl+C”, “Ctrl+V” (1)<br />
NO - When edited, applies the new value to the entire selected cells (2)<br />
OK - Validates that the numbers entered are integers < 10 (3)<br />
<br />
WCF SERVICE<br />
OK - CalcDeterminant: receives a matrix (2D array) and returns the determinant. (4)<br />
OK - FilterAndOrderValues:eceives a matrix, enumerate the values, discards odds,...<br />
OK - Create two uinit-tests for the two methods exposed by the WCF service.<br />
OK - Create a COM class library that connects to the WCF service and wraps its two methods.
<br />
EXCEL FILE
PARTIAL - If you have created the COM visible dll, you can now test it in the Excel attached file.<br />
