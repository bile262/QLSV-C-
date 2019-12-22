namespace Onthi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CTLopHPs", "masv", "dbo.SinhViens");
            DropIndex("dbo.CTLopHPs", new[] { "masv" });
            AddColumn("dbo.CTLopHPs", "hodem", c => c.String());
            AddColumn("dbo.CTLopHPs", "ten", c => c.String());
            AddColumn("dbo.CTLopHPs", "ngaysinh", c => c.DateTime(nullable: false));
            AddColumn("dbo.CTLopHPs", "quequan", c => c.String());
            AlterColumn("dbo.CTLopHPs", "masv", c => c.String());
            DropTable("dbo.SinhViens");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        masv = c.String(nullable: false, maxLength: 128),
                        hodem = c.String(),
                        ten = c.String(),
                        ngaysinh = c.DateTime(nullable: false),
                        quequan = c.String(),
                    })
                .PrimaryKey(t => t.masv);
            
            AlterColumn("dbo.CTLopHPs", "masv", c => c.String(maxLength: 128));
            DropColumn("dbo.CTLopHPs", "quequan");
            DropColumn("dbo.CTLopHPs", "ngaysinh");
            DropColumn("dbo.CTLopHPs", "ten");
            DropColumn("dbo.CTLopHPs", "hodem");
            CreateIndex("dbo.CTLopHPs", "masv");
            AddForeignKey("dbo.CTLopHPs", "masv", "dbo.SinhViens", "masv");
        }
    }
}
