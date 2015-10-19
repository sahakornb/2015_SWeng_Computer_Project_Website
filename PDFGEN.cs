   protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                BaseFont EnCodefont = BaseFont.CreateFont("C:/Users/XeusLab/Documents/THSarabunNew.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font Nfont12 = new Font(EnCodefont, 12, Font.NORMAL);
                Font Nfont16 = new Font(EnCodefont, 16, Font.NORMAL);

                Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();

                PdfPTable table = new PdfPTable(2);
                PdfPCell cell = new PdfPCell();
                cell.Colspan = 2;
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                float[] widths = new float[] { 1f, 9f };
                table.SetWidths(widths);
                table.AddCell(cell);
                table.AddCell(new Paragraph("CPE01", Nfont16));
                table.AddCell(new Paragraph("แบบเสนอหัวข้อโครงงานวิศวกรรมคอมพิวเตอร์ ปีการศึกษาที่ 2558", Nfont16));
            
                pdfDoc.Add(table);

                pdfDoc.Add(new Paragraph("                     ชื่อโครงงาน\n\n", Nfont12));
          
                table = new PdfPTable(2);
                cell = new PdfPCell();
                cell.Colspan = 2;
                // table2
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                table.AddCell(cell);
                table.AddCell(new Paragraph("ภาษาไทย", Nfont12));
                table.AddCell(new Paragraph("ภาษาอังกฤษ", Nfont12));
          
                table.AddCell(new Paragraph("\n\n\n\n", Nfont12));
                table.AddCell(new Paragraph("\n\n\n\n", Nfont12));
                pdfDoc.Add(table);

                pdfDoc.Add(new Paragraph("                     รายชื่อนิสิตผู้ทำโครงงาน\n\n", Nfont12));
                // table3
                table = new PdfPTable(5);
                cell = new PdfPCell();
                cell.Colspan = 5;
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                table.AddCell(cell);
                widths = new float[] { 1f, 6f, 3f, 3f, 6f};
                table.SetWidths(widths);
                table.AddCell(new Paragraph("ที่", Nfont12));
                table.AddCell(new Paragraph("ชื่อ-นามสกุล", Nfont12));
                table.AddCell(new Paragraph("รหัสนิสิต", Nfont12));
                table.AddCell(new Paragraph("เบอร์โทร", Nfont12));
                table.AddCell(new Paragraph("อีเมล์", Nfont12));

                table.AddCell(new Paragraph("1", Nfont12));
                table.AddCell(new Paragraph("\n\n", Nfont12));
                table.AddCell(new Paragraph("\n\n", Nfont12));
                table.AddCell(new Paragraph("\n\n", Nfont12));
                table.AddCell(new Paragraph("\n\n", Nfont12));

                table.AddCell(new Paragraph("2", Nfont12));
                table.AddCell(new Paragraph("\n\n", Nfont12));
                table.AddCell(new Paragraph("\n\n", Nfont12));
                table.AddCell(new Paragraph("\n\n", Nfont12));
                table.AddCell(new Paragraph("\n\n", Nfont12));

                table.AddCell(new Paragraph("3", Nfont12));
                table.AddCell(new Paragraph("\n\n", Nfont12));
                table.AddCell(new Paragraph("\n\n", Nfont12));
                table.AddCell(new Paragraph("\n\n", Nfont12));
                table.AddCell(new Paragraph("\n\n", Nfont12));
                pdfDoc.Add(table);

                pdfDoc.Add(new Paragraph("                     อาจารย์ที่ปรึกษาและกรรมการ\n\n", Nfont12));

                table = new PdfPTable(3);
                cell = new PdfPCell();
                cell.Colspan = 3;
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                table.AddCell(cell);
                table.AddCell(new Paragraph("อาจารย์ที่ปรึกษา", Nfont12));
                table.AddCell(new Paragraph("อาจารย์ที่ปรึกษาร่วม (ถ้ามี)", Nfont12));
                table.AddCell(new Paragraph("เสนอรายชื่อกรรมการ 1 ท่าน", Nfont12));
                table.AddCell(new Paragraph("\n\n\n", Nfont12));
                table.AddCell(new Paragraph("\n\n\n", Nfont12));
                table.AddCell(new Paragraph("\n\n\n", Nfont12));
                pdfDoc.Add(table);

                pdfDoc.Add(new Paragraph("\n\n", Nfont12));
                pdfDoc.Add(new Paragraph("                                                                                                                           ลงชื่อ ..................................................................", Nfont12));
                pdfDoc.Add(new Paragraph("                                                                                                                                 (                                            )", Nfont12));
                pdfDoc.Add(new Paragraph("                                                                                                                                         อาจารย์ที่ปรึกษาโครงาน", Nfont12));
                pdfDoc.Add(new Paragraph("                                                                                                                           วันที่ ..................................................................", Nfont12));

                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Example.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
              
               
            }
            catch (Exception ex)
            { Response.Write(ex.Message); }
        }