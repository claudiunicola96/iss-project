﻿using App.Controller;
using App.Entity;
using App.Factory;
using System;
using System.Windows.Forms;

namespace App.UI.PhaseTwo
{
    /// <summary>
    /// Author: Andu Popa
    /// Author: Ioan Ovidiu Enache
    /// </summary>
    public partial class ChairMain : Form
    {
        private PhaseTwoController phaseTwoController;
        private Form parentForm;
        private User loggedUser;

        public ChairMain(Form parentForm, User loggedUser)
        {
            phaseTwoController = ApplicationFactory.getPhaseTwoController();
            this.parentForm = parentForm;
            this.loggedUser = loggedUser;

            InitializeComponent();
        }

        private void sendEmailsButton_Click(object sender, EventArgs e)
        {
            ChairToAcceptedAuthors sendMailView = new ChairToAcceptedAuthors(this,phaseTwoController, new Utils.MailSender());
            this.Hide();
            sendMailView.SetDesktopLocation(this.Location.X, this.Location.Y);
            sendMailView.Show();
        }

        private void assignButton_Click(object sender, EventArgs e)
        {
            ChairAssignementToReviewer assignmentView = new ChairAssignementToReviewer(this,phaseTwoController);
            this.Hide();
            assignmentView.SetDesktopLocation(this.Location.X, this.Location.Y);
            assignmentView.Show();
        }

        private void ChairMain_Load(object sender, EventArgs e)
        {

        }
    }
}
