<?xml version='1.0' encoding='UTF-8'?>
<Project Type="Project" LVVersion="20008000">
	<Item Name="My Computer" Type="My Computer">
		<Property Name="server.app.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.control.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.tcp.enabled" Type="Bool">false</Property>
		<Property Name="server.tcp.port" Type="Int">0</Property>
		<Property Name="server.tcp.serviceName" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.tcp.serviceName.default" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.vi.callsEnabled" Type="Bool">true</Property>
		<Property Name="server.vi.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="specify.custom.address" Type="Bool">false</Property>
		<Item Name="Source" Type="Folder">
			<Item Name="Coffee Machine" Type="Folder">
				<Item Name="main.vi" Type="VI" URL="../main.vi"/>
				<Item Name="Queue.vi" Type="VI" URL="../Subvi/Queue.vi"/>
			</Item>
			<Item Name="Stricttypedef" Type="Folder">
				<Item Name="Brewing.ctl" Type="VI" URL="../Strict Type Def/Brewing.ctl"/>
				<Item Name="Chamber.ctl" Type="VI" URL="../Strict Type Def/Chamber.ctl"/>
				<Item Name="DataCluster.ctl" Type="VI" URL="../Typedef/DataCluster.ctl"/>
				<Item Name="Dispenser.ctl" Type="VI" URL="../Strict Type Def/Dispenser.ctl"/>
				<Item Name="Dispensing.ctl" Type="VI" URL="../Strict Type Def/Dispensing.ctl"/>
				<Item Name="Grinding.ctl" Type="VI" URL="../Strict Type Def/Grinding.ctl"/>
				<Item Name="Heating.ctl" Type="VI" URL="../Strict Type Def/Heating.ctl"/>
				<Item Name="Low Water.ctl" Type="VI" URL="../Strict Type Def/Low Water.ctl"/>
				<Item Name="LowBean.ctl" Type="VI" URL="../Strict Type Def/LowBean.ctl"/>
				<Item Name="LowMilk.ctl" Type="VI" URL="../Strict Type Def/LowMilk.ctl"/>
				<Item Name="Purging.ctl" Type="VI" URL="../Strict Type Def/Purging.ctl"/>
				<Item Name="QueueOperation.ctl" Type="VI" URL="../Typedef/QueueOperation.ctl"/>
			</Item>
		</Item>
		<Item Name="Read File.vi" Type="VI" URL="../Subvi/Read File.vi"/>
		<Item Name="Shutdowncase.vi" Type="VI" URL="../Subvi/Shutdowncase.vi"/>
		<Item Name="TimeCluster.ctl" Type="VI" URL="../Typedef/TimeCluster.ctl"/>
		<Item Name="Dependencies" Type="Dependencies">
			<Item Name="vi.lib" Type="Folder">
				<Item Name="8.6CompatibleGlobalVar.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/config.llb/8.6CompatibleGlobalVar.vi"/>
				<Item Name="Check if File or Folder Exists.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/libraryn.llb/Check if File or Folder Exists.vi"/>
				<Item Name="Error Cluster From Error Code.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Error Cluster From Error Code.vi"/>
				<Item Name="NI_FileType.lvlib" Type="Library" URL="/&lt;vilib&gt;/Utility/lvfile.llb/NI_FileType.lvlib"/>
				<Item Name="NI_LVConfig.lvlib" Type="Library" URL="/&lt;vilib&gt;/Utility/config.llb/NI_LVConfig.lvlib"/>
				<Item Name="NI_PackedLibraryUtility.lvlib" Type="Library" URL="/&lt;vilib&gt;/Utility/LVLibp/NI_PackedLibraryUtility.lvlib"/>
				<Item Name="Trim Whitespace.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Trim Whitespace.vi"/>
				<Item Name="whitespace.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/whitespace.ctl"/>
			</Item>
		</Item>
		<Item Name="Build Specifications" Type="Build"/>
	</Item>
</Project>
