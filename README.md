# RelativeMouseRDP
<del><B>This Project Has Unfortunatly Been Discontinued Temporarly</B></del><br><br>
<strong>Work on this project will start again soon</strong>
The method that the program uses to get mouse delta and apply inputs is currently not good and sometimes laggy but it does work, until a better way of moving the cursor is discovered this project will stay as it is<br><br>
<h2>About This Software</h2>
This software is a replica of <a href="https://github.com/TKMAX777/RemoteRelativeInput">RemoteRelativeInput</a> by <a href="https://github.com/TKMAX777">TKMAX777</a> with a more user friendly enviorment<br><br>
<h2>Supported OS</h2>
Currently this software is <b>WINDOWS ONLY</b> but it has been written with .NET Core so it could be upgraded<br><br>
<h2>Manual</h2>
<ol>
<li>Download the latest version of software available from Releases</li>
<li>Open the software</li>
<li>Choose the Device Position</li>
<li>Choose the Connection Method</li>
<h3>Server</h3>
<ul type="disc">
<li>Optional, in Connection Specifications put in the IP of the client that you want to have access to Server</li>
<li>in Connection Specifications set the port, the server will only listen to connections via that port(Port value should be the same for Server and Client)</li>
<li>Click Start, When the light is green server has successfully started</li>
</ul>
<h3>Client</h3>
<ul type="disc">
<li>in Connection Specifications put in the IP and the Port of the Server</li>
<li>in Mouse Options, Choose the method of input tracking</li>
<li>Choose the device or window that you want to track the inputs from</li>
<li>Click Start, If Server accpets the request the light will turn green otherwise you'll get rejected</li>
</ul>
</ol>
