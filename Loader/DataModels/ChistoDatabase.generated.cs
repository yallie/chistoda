//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : ovdakyjf
	/// Data Source    : tcp://rogue.db.elephantsql.com:5432
	/// Server Version : 11.2
	/// </summary>
	public partial class ChistoDatabase : LinqToDB.Data.DataConnection
	{
		public ITable<Company>                Companies                { get { return this.GetTable<Company>(); } }
		public ITable<CompanyEquipment>       CompanyEquipments        { get { return this.GetTable<CompanyEquipment>(); } }
		public ITable<CompanyVehicle>         CompanyVehicles          { get { return this.GetTable<CompanyVehicle>(); } }
		public ITable<EquipmentCompatibility> EquipmentCompatibilities { get { return this.GetTable<EquipmentCompatibility>(); } }
		public ITable<EquipmentType>          EquipmentTypes           { get { return this.GetTable<EquipmentType>(); } }
		public ITable<EquipmentUnit>          EquipmentUnits           { get { return this.GetTable<EquipmentUnit>(); } }
		public ITable<Operation>              Operations               { get { return this.GetTable<Operation>(); } }
		public ITable<PgStatStatement>        PgStatStatements         { get { return this.GetTable<PgStatStatement>(); } }
		public ITable<Task>                   Tasks                    { get { return this.GetTable<Task>(); } }
		public ITable<TemplateOperation>      TemplateOperations       { get { return this.GetTable<TemplateOperation>(); } }
		public ITable<TemplateTask>           TemplateTasks            { get { return this.GetTable<TemplateTask>(); } }
		public ITable<TemplateTaskOperation>  TemplateTaskOperations   { get { return this.GetTable<TemplateTaskOperation>(); } }
		public ITable<Vehicle>                Vehicles                 { get { return this.GetTable<Vehicle>(); } }
		public ITable<VehicleEquipment>       VehicleEquipments        { get { return this.GetTable<VehicleEquipment>(); } }
		public ITable<VehicleType>            VehicleTypes             { get { return this.GetTable<VehicleType>(); } }

		partial void InitMappingSchema()
		{
		}

		public ChistoDatabase()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public ChistoDatabase(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table(Schema="public", Name="companies")]
	public partial class Company
	{
		[Column("id"),   PrimaryKey, Identity] public int    Id   { get; set; } // integer
		[Column("name"), NotNull             ] public string Name { get; set; } // character varying

		#region Associations

		/// <summary>
		/// company_equipment_company_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="CompanyId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<CompanyEquipment> Companyequipmentcompanyidfkeys { get; set; }

		/// <summary>
		/// company_vehicles_company_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="CompanyId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<CompanyVehicle> Companyvehiclescompanyidfkeys { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="company_equipment")]
	public partial class CompanyEquipment
	{
		[Column("company_id"),   NotNull] public int CompanyId   { get; set; } // integer
		[Column("equipment_id"), NotNull] public int EquipmentId { get; set; } // integer

		#region Associations

		/// <summary>
		/// company_equipment_company_id_fkey
		/// </summary>
		[Association(ThisKey="CompanyId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="company_equipment_company_id_fkey", BackReferenceName="Companyequipmentcompanyidfkeys")]
		public Company Company { get; set; }

		/// <summary>
		/// company_equipment_equipment_id_fkey
		/// </summary>
		[Association(ThisKey="EquipmentId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="company_equipment_equipment_id_fkey", BackReferenceName="Companyequipmentequipmentidfkeys")]
		public EquipmentUnit Equipment { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="company_vehicles")]
	public partial class CompanyVehicle
	{
		[Column("company_id"), NotNull] public int CompanyId { get; set; } // integer
		[Column("vehicle_id"), NotNull] public int VehicleId { get; set; } // integer

		#region Associations

		/// <summary>
		/// company_vehicles_company_id_fkey
		/// </summary>
		[Association(ThisKey="CompanyId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="company_vehicles_company_id_fkey", BackReferenceName="Companyvehiclescompanyidfkeys")]
		public Company Company { get; set; }

		/// <summary>
		/// company_vehicles_vehicle_id_fkey
		/// </summary>
		[Association(ThisKey="VehicleId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="company_vehicles_vehicle_id_fkey", BackReferenceName="Companyvehicleidfkeys")]
		public Vehicle Vehicle { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="equipment_compatibility")]
	public partial class EquipmentCompatibility
	{
		[Column("vehicle_type_id"),   NotNull] public int VehicleTypeId   { get; set; } // integer
		[Column("equipment_type_id"), NotNull] public int EquipmentTypeId { get; set; } // integer

		#region Associations

		/// <summary>
		/// equipment_compatibility_equipment_type_id_fkey
		/// </summary>
		[Association(ThisKey="EquipmentTypeId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="equipment_compatibility_equipment_type_id_fkey", BackReferenceName="Equipmentcompatibilityequipmenttypeidfkeys")]
		public EquipmentType EquipmentType { get; set; }

		/// <summary>
		/// equipment_compatibility_vehicle_type_id_fkey
		/// </summary>
		[Association(ThisKey="VehicleTypeId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="equipment_compatibility_vehicle_type_id_fkey", BackReferenceName="Equipmentcompatibilityvehicletypeidfkeys")]
		public VehicleType VehicleType { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="equipment_types")]
	public partial class EquipmentType
	{
		[Column("id"),   PrimaryKey, Identity] public int    Id   { get; set; } // integer
		[Column("name"), NotNull             ] public string Name { get; set; } // character varying

		#region Associations

		/// <summary>
		/// equipment_compatibility_equipment_type_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="EquipmentTypeId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<EquipmentCompatibility> Equipmentcompatibilityequipmenttypeidfkeys { get; set; }

		/// <summary>
		/// equipment_units_type_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="TypeId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<EquipmentUnit> Equipmentunitstypeidfkeys { get; set; }

		/// <summary>
		/// template_operations_equipment_type_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="EquipmentTypeId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<TemplateOperation> Templateoperationsequipmenttypeidfkeys { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="equipment_units")]
	public partial class EquipmentUnit
	{
		[Column("id"),      PrimaryKey, Identity] public int    Id     { get; set; } // integer
		[Column("type_id"), NotNull             ] public int    TypeId { get; set; } // integer
		[Column("name"),    NotNull             ] public string Name   { get; set; } // character varying

		#region Associations

		/// <summary>
		/// company_equipment_equipment_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="EquipmentId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<CompanyEquipment> Companyequipmentequipmentidfkeys { get; set; }

		/// <summary>
		/// equipment_units_type_id_fkey
		/// </summary>
		[Association(ThisKey="TypeId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="equipment_units_type_id_fkey", BackReferenceName="Equipmentunitstypeidfkeys")]
		public EquipmentType Type { get; set; }

		/// <summary>
		/// vehicle_equipment_equipment_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="EquipmentId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<VehicleEquipment> Vehicleequipmentequipmentidfkeys { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="operations")]
	public partial class Operation
	{
		[Column("id"),                    PrimaryKey, Identity] public int    Id                  { get; set; } // integer
		[Column("task_id"),               NotNull             ] public int    TaskId              { get; set; } // integer
		[Column("order_number"),          NotNull             ] public int    OrderNumber         { get; set; } // integer
		[Column("template_operation_id"), NotNull             ] public int    TemplateOperationId { get; set; } // integer
		[Column("name"),                  NotNull             ] public string Name                { get; set; } // character varying

		#region Associations

		/// <summary>
		/// operations_task_id_fkey
		/// </summary>
		[Association(ThisKey="TaskId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="operations_task_id_fkey", BackReferenceName="Operationstaskidfkeys")]
		public Task Task { get; set; }

		/// <summary>
		/// operations_template_operation_id_fkey
		/// </summary>
		[Association(ThisKey="TemplateOperationId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="operations_template_operation_id_fkey", BackReferenceName="Operationstemplateoperationidfkeys")]
		public TemplateOperation TemplateOperation { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="pg_stat_statements", IsView=true)]
	public partial class PgStatStatement
	{
		[Column("userid",              SkipOnUpdate=true), Nullable] public int?    Userid            { get; set; } // oid
		[Column("dbid",                SkipOnUpdate=true), Nullable] public int?    Dbid              { get; set; } // oid
		[Column("queryid",             SkipOnUpdate=true), Nullable] public long?   Queryid           { get; set; } // bigint
		[Column("query",               SkipOnUpdate=true), Nullable] public string  Query             { get; set; } // text
		[Column("calls",               SkipOnUpdate=true), Nullable] public long?   Calls             { get; set; } // bigint
		[Column("total_time",          SkipOnUpdate=true), Nullable] public double? TotalTime         { get; set; } // double precision
		[Column("min_time",            SkipOnUpdate=true), Nullable] public double? MinTime           { get; set; } // double precision
		[Column("max_time",            SkipOnUpdate=true), Nullable] public double? MaxTime           { get; set; } // double precision
		[Column("mean_time",           SkipOnUpdate=true), Nullable] public double? MeanTime          { get; set; } // double precision
		[Column("stddev_time",         SkipOnUpdate=true), Nullable] public double? StddevTime        { get; set; } // double precision
		[Column("rows",                SkipOnUpdate=true), Nullable] public long?   Rows              { get; set; } // bigint
		[Column("shared_blks_hit",     SkipOnUpdate=true), Nullable] public long?   SharedBlksHit     { get; set; } // bigint
		[Column("shared_blks_read",    SkipOnUpdate=true), Nullable] public long?   SharedBlksRead    { get; set; } // bigint
		[Column("shared_blks_dirtied", SkipOnUpdate=true), Nullable] public long?   SharedBlksDirtied { get; set; } // bigint
		[Column("shared_blks_written", SkipOnUpdate=true), Nullable] public long?   SharedBlksWritten { get; set; } // bigint
		[Column("local_blks_hit",      SkipOnUpdate=true), Nullable] public long?   LocalBlksHit      { get; set; } // bigint
		[Column("local_blks_read",     SkipOnUpdate=true), Nullable] public long?   LocalBlksRead     { get; set; } // bigint
		[Column("local_blks_dirtied",  SkipOnUpdate=true), Nullable] public long?   LocalBlksDirtied  { get; set; } // bigint
		[Column("local_blks_written",  SkipOnUpdate=true), Nullable] public long?   LocalBlksWritten  { get; set; } // bigint
		[Column("temp_blks_read",      SkipOnUpdate=true), Nullable] public long?   TempBlksRead      { get; set; } // bigint
		[Column("temp_blks_written",   SkipOnUpdate=true), Nullable] public long?   TempBlksWritten   { get; set; } // bigint
		[Column("blk_read_time",       SkipOnUpdate=true), Nullable] public double? BlkReadTime       { get; set; } // double precision
		[Column("blk_write_time",      SkipOnUpdate=true), Nullable] public double? BlkWriteTime      { get; set; } // double precision
	}

	[Table(Schema="public", Name="tasks")]
	public partial class Task
	{
		[Column("id"),               PrimaryKey, Identity] public int            Id             { get; set; } // integer
		[Column("template_task_id"), NotNull             ] public int            TemplateTaskId { get; set; } // integer
		[Column("name"),             NotNull             ] public string         Name           { get; set; } // character varying
		[Column("date"),             NotNull             ] public DateTimeOffset Date           { get; set; } // timestamp (0) with time zone
		[Column("quantity"),         NotNull             ] public decimal        Quantity       { get; set; } // numeric

		#region Associations

		/// <summary>
		/// operations_task_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="TaskId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Operation> Operationstaskidfkeys { get; set; }

		/// <summary>
		/// tasks_template_task_id_fkey
		/// </summary>
		[Association(ThisKey="TemplateTaskId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="tasks_template_task_id_fkey", BackReferenceName="Taskstemplatetaskidfkeys")]
		public TemplateTask TemplateTask { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="template_operations")]
	public partial class TemplateOperation
	{
		[Column("id"),                PrimaryKey,  Identity] public int     Id              { get; set; } // integer
		[Column("name"),              NotNull              ] public string  Name            { get; set; } // character varying
		[Column("vehicle_type_id"),      Nullable          ] public int?    VehicleTypeId   { get; set; } // integer
		[Column("equipment_type_id"),    Nullable          ] public int?    EquipmentTypeId { get; set; } // integer
		[Column("speed"),             NotNull              ] public decimal Speed           { get; set; } // numeric

		#region Associations

		/// <summary>
		/// template_operations_equipment_type_id_fkey
		/// </summary>
		[Association(ThisKey="EquipmentTypeId", OtherKey="Id", CanBeNull=true, Relationship=Relationship.ManyToOne, KeyName="template_operations_equipment_type_id_fkey", BackReferenceName="Templateoperationsequipmenttypeidfkeys")]
		public EquipmentType EquipmentType { get; set; }

		/// <summary>
		/// operations_template_operation_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="TemplateOperationId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Operation> Operationstemplateoperationidfkeys { get; set; }

		/// <summary>
		/// template_task_operations_template_operation_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="TemplateOperationId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<TemplateTaskOperation> Templatetaskoperationstemplateoperationidfkeys { get; set; }

		/// <summary>
		/// template_operations_vehicle_type_id_fkey
		/// </summary>
		[Association(ThisKey="VehicleTypeId", OtherKey="Id", CanBeNull=true, Relationship=Relationship.ManyToOne, KeyName="template_operations_vehicle_type_id_fkey", BackReferenceName="Templateoperationsvehicletypeidfkeys")]
		public VehicleType VehicleType { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="template_tasks")]
	public partial class TemplateTask
	{
		[Column("id"),   PrimaryKey, Identity] public int    Id   { get; set; } // integer
		[Column("name"), NotNull             ] public string Name { get; set; } // character varying

		#region Associations

		/// <summary>
		/// tasks_template_task_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="TemplateTaskId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Task> Taskstemplatetaskidfkeys { get; set; }

		/// <summary>
		/// template_task_operations_template_task_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="TemplateTaskId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<TemplateTaskOperation> Templatetaskoperationstemplatetaskidfkeys { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="template_task_operations")]
	public partial class TemplateTaskOperation
	{
		[Column("template_task_id"),      NotNull] public int TemplateTaskId      { get; set; } // integer
		[Column("template_operation_id"), NotNull] public int TemplateOperationId { get; set; } // integer
		[Column("order_number"),          NotNull] public int OrderNumber         { get; set; } // integer

		#region Associations

		/// <summary>
		/// template_task_operations_template_operation_id_fkey
		/// </summary>
		[Association(ThisKey="TemplateOperationId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="template_task_operations_template_operation_id_fkey", BackReferenceName="Templatetaskoperationstemplateoperationidfkeys")]
		public TemplateOperation TemplateOperation { get; set; }

		/// <summary>
		/// template_task_operations_template_task_id_fkey
		/// </summary>
		[Association(ThisKey="TemplateTaskId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="template_task_operations_template_task_id_fkey", BackReferenceName="Templatetaskoperationstemplatetaskidfkeys")]
		public TemplateTask TemplateTask { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="vehicles")]
	public partial class Vehicle
	{
		[Column("id"),      PrimaryKey, Identity] public int    Id     { get; set; } // integer
		[Column("type_id"), NotNull             ] public int    TypeId { get; set; } // integer
		[Column("name"),    NotNull             ] public string Name   { get; set; } // character varying

		#region Associations

		/// <summary>
		/// company_vehicles_vehicle_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="VehicleId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<CompanyVehicle> Companyvehicleidfkeys { get; set; }

		/// <summary>
		/// vehicles_type_id_fkey
		/// </summary>
		[Association(ThisKey="TypeId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="vehicles_type_id_fkey", BackReferenceName="Vehiclestypeidfkeys")]
		public VehicleType Type { get; set; }

		/// <summary>
		/// vehicle_equipment_vehicle_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="VehicleId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<VehicleEquipment> Vehicleequipmentvehicleidfkeys { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="vehicle_equipment")]
	public partial class VehicleEquipment
	{
		[Column("vehicle_id"),   NotNull] public int VehicleId   { get; set; } // integer
		[Column("equipment_id"), NotNull] public int EquipmentId { get; set; } // integer

		#region Associations

		/// <summary>
		/// vehicle_equipment_equipment_id_fkey
		/// </summary>
		[Association(ThisKey="EquipmentId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="vehicle_equipment_equipment_id_fkey", BackReferenceName="Vehicleequipmentequipmentidfkeys")]
		public EquipmentUnit Equipment { get; set; }

		/// <summary>
		/// vehicle_equipment_vehicle_id_fkey
		/// </summary>
		[Association(ThisKey="VehicleId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="vehicle_equipment_vehicle_id_fkey", BackReferenceName="Vehicleequipmentvehicleidfkeys")]
		public Vehicle Vehicle { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="vehicle_types")]
	public partial class VehicleType
	{
		[Column("id"),   PrimaryKey, Identity] public int    Id   { get; set; } // integer
		[Column("name"), NotNull             ] public string Name { get; set; } // character varying

		#region Associations

		/// <summary>
		/// equipment_compatibility_vehicle_type_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="VehicleTypeId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<EquipmentCompatibility> Equipmentcompatibilityvehicletypeidfkeys { get; set; }

		/// <summary>
		/// template_operations_vehicle_type_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="VehicleTypeId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<TemplateOperation> Templateoperationsvehicletypeidfkeys { get; set; }

		/// <summary>
		/// vehicles_type_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="TypeId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Vehicle> Vehiclestypeidfkeys { get; set; }

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Company Find(this ITable<Company> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static EquipmentType Find(this ITable<EquipmentType> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static EquipmentUnit Find(this ITable<EquipmentUnit> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static Operation Find(this ITable<Operation> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static Task Find(this ITable<Task> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static TemplateOperation Find(this ITable<TemplateOperation> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static TemplateTask Find(this ITable<TemplateTask> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static Vehicle Find(this ITable<Vehicle> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static VehicleType Find(this ITable<VehicleType> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}
	}
}

#pragma warning restore 1591