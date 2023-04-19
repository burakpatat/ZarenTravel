using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    [Table("DesignSchemes", Schema = "dbo")]
    public partial class DesignScheme
    {
        public string colors_body_background { get; set; }

        public string colors_body_font { get; set; }

        public int? colors_body_font_size { get; set; }

        public string colors_body_font_color { get; set; }

        public string colors_content_text_color { get; set; }

        public string colors_content_border_color { get; set; }

        public string colors_content_background { get; set; }

        public string colors_content_padding { get; set; }

        public string colors_content_margin { get; set; }

        public string colors_menu_padding { get; set; }

        public int? colors_menu_font_size { get; set; }

        public string colors_menu_background { get; set; }

        public string colors_menu_margin { get; set; }

        public string colors_header_padding { get; set; }

        public int? colors_header_font_size { get; set; }

        public string colors_header_background { get; set; }

        public string colors_header_margin { get; set; }

        public string colors_footer_padding { get; set; }

        public int? colors_footer_font_size { get; set; }

        public string colors_footer_background { get; set; }

        public string colors_footer_margin { get; set; }

        public string colors_wrapper_padding { get; set; }

        public int? colors_wrapper_font_size { get; set; }

        public string colors_wrapper_background { get; set; }

        public string colors_wrapper_margin { get; set; }

        public int? colors_wrapper_width { get; set; }

        public string colors_group { get; set; }

        public int? colors_color1_rgb { get; set; }

        public decimal? colors_color1_brightness { get; set; }

        public string colors_color1_isDark { get; set; }

        public int? colors_color2_hex { get; set; }

        public int? colors_color2_rgb { get; set; }

        public decimal? colors_color2_brightness { get; set; }

        public string colors_color2_isDark { get; set; }

        public int? colors_color3_hex { get; set; }

        public int? colors_color3_rgb { get; set; }

        public decimal? colors_color3_brightness { get; set; }

        public string colors_color3_isDark { get; set; }

        public int? colors_color4_hex { get; set; }

        public int? colors_color4_rgb { get; set; }

        public decimal? colors_color4_brightness { get; set; }

        public string colors_color4_isDark { get; set; }

        public int? colors_color5_hex { get; set; }

        public int? colors_color5_rgb { get; set; }

        public decimal? colors_color5_brightness { get; set; }

        public string colors_color5_isDark { get; set; }

    }
}