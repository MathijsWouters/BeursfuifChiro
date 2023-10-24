namespace beursfuif
{
    partial class GuideForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WindowState = FormWindowState.Maximized;
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Location = new Point(0, 0);
            tabControl1.Size = new Size(this.ClientSize.Width, (int)(this.ClientSize.Height * 0.95));
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;

            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(192, 72);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Guide";
            tabPage1.UseVisualStyleBackColor = true;
            Label guideLabel = new Label();
            guideLabel.Text = @"Handleiding: Hoe het programma werkt

1. Drankjes toevoegen:

Klik op de knop 'Add drinks' om een drankje toe te voegen.
Geef het drankje een naam en kies een kleur. Zorg ervoor dat de kleur niet te donker is.
Stel de minimale en maximale prijs in, evenals een interval (bij voorkeur kleiner dan 1).
Bepaal een drempelwaarde. Elk drankje dat deze drempel bereikt binnen een periode van 5 minuten, heeft de volgende mogelijkheden:
33% kans om dezelfde prijs te behouden.
33% kans om met 1 interval in prijs te stijgen.
33% kans om met 2 intervallen te stijgen.
Als de drempel niet wordt gehaald, kan de prijs gelijk blijven of dalen.

2. Feestje starten:

Klik op de knop 'Start feestje' om de timer te starten. Hierdoor zal de grafiek beginnen te veranderen en de prijzen van de drankjes zullen variëren.
Let op: Zorg ervoor dat er drankjes zijn toegevoegd voordat je het feestje start.

3. Crash functie:

Door op de 'Crash' knop te drukken, worden de prijzen van de drankjes gedurende 5 minuten naar hun minimumprijs gebracht. Na deze periode zullen ze willekeurig veranderen.

4. Drankjes verwijderen:

Om een drankje te verwijderen, klik je eerst op de betreffende knop en vervolgens op 'Confirm'.

5. Programma afsluiten:

Je kunt het programma op elk moment sluiten met de 'Sluit' knop. Alle toegevoegde drankjes worden onthouden en zijn beschikbaar wanneer je het programma de volgende keer opent.

6. Verkoopgegevens:

Het programma berekent het totaal aantal verkochte eenheden van elk drankje en de totale winst. Door op 'Stop feestje' te klikken, worden deze gegevens opgeslagen in een Excel-bestand in je downloads map.

7. Sneltoetsen:

Elk drankje kan snel worden geselecteerd met het corresponderende nummer op het numpad.
Om het laatste item uit je bestelling te verwijderen, druk je op de 'Delete' knop op je toetsenbord.
Voor het initiëren van crashes gebruik je de 'Tab' knop.";
            guideLabel.AutoSize = false;
            guideLabel.TextAlign = ContentAlignment.TopLeft;
            guideLabel.Dock = DockStyle.Fill;
            tabPage1.Controls.Add(guideLabel);

            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(192, 72);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Rules";
            tabPage2.UseVisualStyleBackColor = true;
            Label messageLabel = new Label();
            messageLabel.Text = "Heb plezier en maak het niet kapot alstublieft\n-Mathijs Wouters";
            messageLabel.AutoSize = false;  
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;  
            messageLabel.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(messageLabel);
            // Close Button
            closeButton = new Button();
            closeButton.Text = "Close";
            closeButton.Size = new Size(100, 25);
            dontShowAgainCheckbox = new CheckBox();
            dontShowAgainCheckbox.Text = "Don't Show Again";
            dontShowAgainCheckbox.AutoSize = true;
            closeButton.Click += CloseButton_Click;
            this.Controls.Add(closeButton);
            this.Controls.Add(dontShowAgainCheckbox);
            PositionControls();
            // 
            // GuideForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "GuideForm";
            Text = "Lees dit even door";
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private CheckBox dontShowAgainCheckbox;
        private Button closeButton;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}